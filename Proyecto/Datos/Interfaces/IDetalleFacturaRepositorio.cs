using Modelos;

namespace Datos.Interfaces
{
    internal interface IDetalleFacturaRepositorio
    {
        Task<bool> Nuevo(DetalleFactura detalleFactura);
    }
}
