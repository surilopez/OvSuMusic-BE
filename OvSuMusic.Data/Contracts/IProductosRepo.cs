using System.Collections.Generic;
using System.Threading.Tasks;
using OvSuMusic.Models;

namespace OvSuMusic.Data.Contracts
{

    public interface IProductosRepo
    {
        Task<List<Producto>> ObtenerProductosAsync();
        Task<Producto> ObtenerProductoAsync(int id);
        Task<Producto> Agregar(Producto producto);
        Task<bool> Actualizar(Producto producto);
        Task<bool> Eliminar(int id);
    }

}
