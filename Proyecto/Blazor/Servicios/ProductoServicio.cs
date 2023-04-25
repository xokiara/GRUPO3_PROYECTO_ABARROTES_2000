using Blazor.Interfaces;
using Datos.Interfaces;
using Datos.Repositorios;
using Modelos;

namespace Blazor.Servicios
{
    //Heredamos de IProductoServicio
    public class ProductoServicio : IProductoServicio
    {
        private readonly Config _config;
        private IProductoRepositorio productoRepositorio;

        //Constructor
        public ProductoServicio(Config config)
        {
            _config = config;
            productoRepositorio = new ProductoRepositorio(config.CadenaConexion);
        }

        public async Task<bool> ActualizarAsync(Producto producto)
        {
            //Retornamos la tarea del productoRepositorio y llamamos el metodo actualizar y le pasamos el parametro
            return await productoRepositorio.ActualizarAsync(producto);
        }

        public async Task<bool> EliminarAsync(string codigo)
        {
            //retornamos el metodo de eliminar
            return await productoRepositorio.EliminarAsync(codigo);
        }

        public async Task<IEnumerable<Producto>> GetListaAsync()
        {
            //retornamos la lista de productos
            return await productoRepositorio.GetListaAsync();
        }

        public async Task<Producto> GetPorCodigoAsync(string codigo)
        {
            //retornamos el metodo
            return await productoRepositorio.GetPorCodigoAsync(codigo);
        }

        public async Task<bool> NuevoAsync(Producto producto)
        {
            //retornamos el metodo de nuevo producto
            return await productoRepositorio.NuevoAsync(producto);
        }
    }
}
