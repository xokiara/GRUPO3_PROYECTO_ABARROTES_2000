using Blazor.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace Blazor.Pages.Clientes
{
    public partial class NuevoCliente 
    {

        [Inject] private IClienteServicio clienteServicio { get; set; }
        [Inject] private NavigationManager navigationManager { get; set; }
        [Inject] private SweetAlertService Swal { get; set; }

        Cliente client = new Cliente();


        protected async void Cancelar()
        {
            navigationManager.NavigateTo("/Clientes");
        }
    }
}
