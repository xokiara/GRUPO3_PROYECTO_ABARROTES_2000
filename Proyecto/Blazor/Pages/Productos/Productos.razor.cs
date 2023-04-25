using Blazor.Interfaces;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace Blazor.Pages.Productos
{
    public partial class Productos
    {
        [Inject] IProductoServicio productoServicio { get; set; } //Inyectamos el servicio
        IEnumerable<Producto> listaProductos { get; set; } //Declaramos una lista

        //SOBREESCRIMINOS EL METODO PARA PODER CARGAR LA LISTA EL INICIO
        protected override async Task OnInitializedAsync()
        {
            listaProductos = await productoServicio.GetListaAsync();
        }

    }
}
