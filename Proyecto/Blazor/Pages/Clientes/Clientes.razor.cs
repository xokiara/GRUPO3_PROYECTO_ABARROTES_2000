using Blazor.Interfaces;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace Blazor.Pages.Clientes
{
    public partial class Clientes
    {
        //Inyectamos el Servicio Cliente
        [Inject] private IClienteServicio clienteServicio { get; set; }

        //Declarar Lista de Clientes
        private IEnumerable<Cliente> listaClientes { get; set; }

        //Sobreescribe el Metodo que Carga Cuando se Ejecute el Componente
        protected override async Task OnInitializedAsync()
        {
            listaClientes = await clienteServicio.GetListaAsync();
        }
    }
}
