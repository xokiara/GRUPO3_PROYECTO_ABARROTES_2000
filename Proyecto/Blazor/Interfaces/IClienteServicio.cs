using Modelos;

namespace Blazor.Interfaces
{
    public interface IClienteServicio
    {
        Task<Cliente> GetPorCodigoAsync(string identidad);
        Task<bool> NuevoAsync(Cliente cliente);
        Task<bool> ActualizarAsync(Cliente cliente);
        //Duda string Identidad?
        Task<bool> EliminarAsync(string codigo);
        Task<IEnumerable<Cliente>> GetListaAsync();
    }
}
