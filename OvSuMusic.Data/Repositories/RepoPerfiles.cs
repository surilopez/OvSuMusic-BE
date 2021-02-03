
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OvSuMusic.Data;
using OvSuMusic.Data.Contracts;
using OvSuMusic.Models;

namespace OvSuMusic.Data.Repositories
{
    public class RepoPerfiles : IGenericRepo<Perfil>
    {
        private readonly TiendaDbContext _context;
        private readonly ILogger<RepoPerfiles> _logger;
        private DbSet<Perfil> _dbSet;

        public RepoPerfiles(TiendaDbContext context, ILogger<RepoPerfiles> logger)
        {
            this._context = context;
            this._logger = logger;
            this._dbSet = _context.Set<Perfil>();
        }
        public async Task<bool> Actualizar(Perfil entity)
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

        public async Task<Perfil> Agregar(Perfil entity)
        {
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
            _dbSet.Remove(entity);
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

        public async Task<Perfil> ObtenerAsync(int id)
        {
            return await _dbSet.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Perfil>> ObtenerTodosAsync()
        {
            return await _dbSet.ToListAsync();
        }
    }
}
