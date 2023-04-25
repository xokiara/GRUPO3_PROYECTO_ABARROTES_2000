using Modelos;

namespace Datos.Interfaces
{
    public interface IProductoRepositorio
    {
        //DECLARACION DE LOS METODOS

        //METODO PARA CREAR UN NUEVO REGISTRO
        Task<bool> NuevoAsync(Producto producto);

        //METODO PARA ACTUALIZAR REGISTRO
        Task<bool> ActualizarAsync(Producto producto);

        //METODO PARA ELIMINAR REGISTRO
        Task<bool> EliminarAsync(string codigo);

        //METODO PARA RETORNAR TODA LA LISTA DE PRODUCTO
        Task<IEnumerable<Producto>> GetListaAsync();

        //METODO ASINCRONO PARA RETORNAR TODO EL OBJETO DE PRODUCTO
        Task<Producto> GetPorCodigoAsync(string codigo);
    }
}
