using Blazor.Interfaces;
using Blazor.Pages.Usuarios;
using Datos.Interfaces;
using Datos.Repositorios;
using Modelos;

namespace Blazor.Servicios
{
    public class ClienteServicio : IClienteServicio
    {
        private readonly Config _config;
        private IClienteRepositorio clienteRepositorio;

        public ClienteServicio(Config config)
        {
            _config = config;
            clienteRepositorio = new ClienteRepositorio(config.CadenaConexion);
        }

        public async Task<bool> ActualizarAsync(Cliente cliente)
        {
            return await clienteRepositorio.ActualizarAsync(cliente);
        }

        public async Task<bool> EliminarAsync(string codigo)
        {
            return await clienteRepositorio.EliminarAsync(codigo);
        }

        public async Task<IEnumerable<Cliente>> GetListaAsync()
        {
            return await clienteRepositorio.GetListaAsync();
        }

        //dudas
        public async Task<Cliente> GetPorCodigoAsync(string codigo)
        {
            return await clienteRepositorio.GetPorCodigoAsync(codigo);
        }

        public async Task<bool> NuevoAsync(Cliente cliente)
        {
            return await clienteRepositorio.NuevoAsync(cliente);
        }
    }
}
