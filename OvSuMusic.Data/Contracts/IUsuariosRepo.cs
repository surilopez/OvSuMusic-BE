
using System.Threading.Tasks;
using OvSuMusic.Models;

namespace OvSuMusic.Data.Contracts
{
    public interface IUsuariosRepo : IGenericRepo<Usuario>
    {
        Task<bool> CambiarContrasena(Usuario usuario);
        Task<bool> CambiarPerfil(Usuario usuario);
        Task<bool> ValidarContrasena(Usuario usuario);
    }
}
