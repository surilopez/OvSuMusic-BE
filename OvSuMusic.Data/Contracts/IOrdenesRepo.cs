using System.Collections.Generic;
using System.Threading.Tasks;
using OvSuMusic.Models;

namespace OvSuMusic.Data.Contracts
{
    public interface IOrdenesRepo: IGenericRepo<Orden>
    {
        Task<IEnumerable<Orden>> ObtenerTodosConDetallesAsync();
        Task<Orden> ObtenerConDetallesAsync(int id);
    }
}
