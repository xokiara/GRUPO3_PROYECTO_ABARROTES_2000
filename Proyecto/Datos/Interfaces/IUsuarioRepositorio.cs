using Modelos;

namespace Datos.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<Usuario> GetPorCodigoAsync(string codigoUsuario);
        Task<bool> NuevoAsync(Usuario usuario);
        Task<bool> ActualizarAsync(Usuario usuario);
        Task<bool> EliminarAsync(string codigo);
        Task<IEnumerable<Usuario>> GetListaAsync();

    }
}
