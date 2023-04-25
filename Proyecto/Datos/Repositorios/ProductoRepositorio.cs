using Datos.Interfaces;
using Modelos;

namespace Datos.Repositorios
{
    //HEREDAMOS DE LA INTERFAZ IProductoRepositorio
    public class ProductoRepositorio : IProductoRepositorio
    {

        public Task<bool> ActualizarAsync(Producto producto)
        {
            throw new NotImplementedException()
        }

        public Task<bool> EliminarAsync(string codigo)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Producto>> GetListaAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Producto> GetPorCodigoAsync(string codigo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> NuevoAsync(Producto producto)
        {
            throw new NotImplementedException();
        }
    }
}
