using Blazor.Interfaces;
using Blazor.Servicios;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace Blazor.Pages.Clientes
{
    public partial class EditarCliente
    {
        [Inject] private IClienteServicio clienteServicio { get; set; }
        [Inject] private NavigationManager navigationManager { get; set; }
        [Inject] private SweetAlertService Swal { get; set; }

        Cliente client = new Cliente();

        [Parameter] public string Identidad { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(Identidad))
            {
                client = await clienteServicio.GetPorCodigoAsync(Identidad);
            }
        }
        protected async void Guardar()
        {
            if (string.IsNullOrWhiteSpace(client.Identidad) || string.IsNullOrWhiteSpace(client.Nombre))
            {
                return;
            }
           
            bool edito = await clienteServicio.ActualizarAsync(client);

            if (edito)
            {
                await Swal.FireAsync("Feliciddades", "Cliente Actualizado con Exito", SweetAlertIcon.Success);
            }
            else
            {
                await Swal.FireAsync("Error", "No Se Pudo Actualizar el Cliente", SweetAlertIcon.Error);
            }
        }

        protected async void Cancelar()
        {
            navigationManager.NavigateTo("/Clientes");
        }

        protected async void Eliminar()
        {
            SweetAlertResult result = await Swal.FireAsync(new SweetAlertOptions
            {
                Title = "¿Esta Seguro que Desea Eliminar el Cliente? ",
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true,
                ConfirmButtonText = "Aceptar",
                CancelButtonText = "Cancelar",
            });

            if (!string.IsNullOrEmpty(result.Value))
            {
                bool elimino = await clienteServicio.EliminarAsync(client.Identidad);

                if (elimino)
                {
                    await Swal.FireAsync("Excelente", "Cliente Eliminado", SweetAlertIcon.Success);
                    navigationManager.NavigateTo("/Clientes");
                }
                else
                {
                    await Swal.FireAsync("Error", "No Se Pudo Eliminar el Cliente", SweetAlertIcon.Error);
                }
            }
        }
    }
}
