using Blazor.Interfaces;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace Blazor.Pages.Clientes
{
    public partial class Clientes
    {
        //duda
        [Inject] private IClienteServicio clienteServicio { get; set; }

        private IEnumerable<Cliente> listaClientes { get; set; }

        protected override async Task OnInitializedAsync()
        {
            listaClientes = await clienteServicio.GetListaAsync();
        }
    }
}
