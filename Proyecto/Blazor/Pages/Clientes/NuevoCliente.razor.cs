using Blazor.Interfaces;
using Blazor.Servicios;
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

        protected async void Guardar()
        {
            if (string.IsNullOrWhiteSpace(client.Identidad) || string.IsNullOrWhiteSpace(client.Nombre))
            {
                return;
            }
            client.FechaNacimiento = DateTime.Now;
            bool inserto = await clienteServicio.NuevoAsync(client);

            if (inserto)
            {
                await Swal.FireAsync("Felicidades", "Cliente Guardado", SweetAlertIcon.Success);
            }
            else
            {
                await Swal.FireAsync("Error", "No Se Pudo Guardar el Cliente", SweetAlertIcon.Error);
            }
        }

        protected async void Cancelar()
        {
            navigationManager.NavigateTo("/Clientes");
        }
    }
}
