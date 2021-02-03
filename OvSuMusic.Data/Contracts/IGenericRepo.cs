using System.Collections.Generic;
using System.Threading.Tasks;

namespace OvSuMusic.Data.Contracts
{
    public interface IGenericRepo<T> where T : class
    {
        Task<IEnumerable<T>> ObtenerTodosAsync();
        Task<T> ObtenerAsync(int id);
        Task<T> Agregar(T entity);
        Task<bool> Actualizar(T entity);
        Task<bool> Eliminar(int id);
    }
}
