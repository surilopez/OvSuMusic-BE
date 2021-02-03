using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OvSuMusic.Data.Contracts;
using OvSuMusic.Models;
using OvSuMusic.Models.Enumerations;

namespace OvSuMusic.Data.Repositories
{
    public class RepoOrdenes : IOrdenesRepo
    {
        private readonly TiendaDbContext _context;
        private readonly ILogger<RepoPerfiles> _logger;
        private DbSet<Orden> _dbSet;

        public RepoOrdenes(TiendaDbContext contexto, ILogger<RepoPerfiles> logger)
        {
            this._context = contexto;
            this._logger = logger;
            this._dbSet = _context.Set<Orden>();
        }

        public async Task<bool> Actualizar(Orden entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            try
            {
                return await _context.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception excepcion)
            {
                _logger.LogError($"Error en {nameof(Actualizar)}: " + excepcion.Message);
            }
            return false;
        }

        public async Task<Orden> Agregar(Orden entity)
        {
            entity.EstatusOrden = EstatusOrden.Activo;
            entity.FechaRegistro = DateTime.UtcNow;            
            _dbSet.Add(entity);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception excepcion)
            {
                _logger.LogError($"Error en {nameof(Agregar)}: " + excepcion.Message);
                return null;
            }
            return entity;
        }

        public async Task<bool> Eliminar(int id)
        {
            var entity = await _dbSet.SingleOrDefaultAsync(u => u.Id == id);
            entity.EstatusOrden = EstatusOrden.Inactivo;            
            try
            {
                return (await _context.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception excepcion)
            {
                _logger.LogError($"Error en {nameof(Eliminar)}: " + excepcion.Message);
            }
            return false;
        }

        public async Task<Orden> ObtenerAsync(int id)
        {
            return await _dbSet.Include(orden=>orden.Usuario)                    
                                .SingleOrDefaultAsync(c => c.Id == id 
                                && c.EstatusOrden == EstatusOrden.Activo);
        }

        public async Task<Orden> ObtenerConDetallesAsync(int id)
        {
            var result = await _dbSet.Include(orden => orden.Usuario)
                                .Include(orden => orden.DetalleOrdens)
                                    .ThenInclude(detalleOrden => detalleOrden.Producto)
                                .SingleOrDefaultAsync(c => c.Id == id
                                && c.EstatusOrden == EstatusOrden.Activo);
            return result;
        }

        public async Task<IEnumerable<Orden>> ObtenerTodosAsync()
        {
            return await _dbSet.Where(u=>u.EstatusOrden== EstatusOrden.Activo)
                                .Include(orden => orden.Usuario)                                                               
                                .ToListAsync();
        }

        public async Task<IEnumerable<Orden>> ObtenerTodosConDetallesAsync()
        {
            return await _dbSet.Where(u => u.EstatusOrden == EstatusOrden.Activo)
                                .Include(orden => orden.Usuario)
                                .Include(orden => orden.DetalleOrdens)
                                    .ThenInclude(detalleOrden => detalleOrden.Producto)
                                .ToListAsync();
        }

    }
}
