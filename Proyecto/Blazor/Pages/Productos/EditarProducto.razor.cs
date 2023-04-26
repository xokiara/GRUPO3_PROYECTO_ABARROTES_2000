using Blazor.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Modelos;

namespace Blazor.Pages.Productos
{
    public partial class EditarProducto
    {
        [Inject] private IProductoServicio productoServicio { get; set; } //Inyectamos el servicio

        [Inject] private NavigationManager navigationManager { get; set; } //Objeto de navegacion
        [Inject] private SweetAlertService Swal { get; set; } //Inyectamos el sweetalert

        Producto producto = new Producto(); //Objeto de producto

        [Parameter] public string Codigo { get; set; } //resive el parametro
        string imgUrl = string.Empty; //Variable global para la foto

        //SOBRESCRIBIMOS EL METODO 
        protected override async Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(Codigo))
            {
                producto = await productoServicio.GetPorCodigoAsync(Codigo);
            }
        }

        //METODO PARA SELECCIONAR LA FOTO
        private async Task SeleccionarImagen(InputFileChangeEventArgs e)
        {
            //Capturamos lo que el usuario a seleccionado
            IBrowserFile imgFile = e.File;
            var buffers = new byte[imgFile.Size];
            producto.Foto = buffers; //Le pasamos el arreglo de byte
            await imgFile.OpenReadStream().ReadAsync(buffers);
            string imageType = imgFile.ContentType;
            //Para poder visualizar en pantalla
            imgUrl = $"data:{imageType};base64,{Convert.ToBase64String(buffers)}";
        }

        //METODO DE GUARDAR
        protected async Task Guardar()
        {
            //Valida que los campos no esten vacio o que este con espacios en blanco
            if (string.IsNullOrWhiteSpace(producto.Codigo) || string.IsNullOrWhiteSpace(producto.Descripcion))
            {
                return;
            }

            bool edito = await productoServicio.ActualizarAsync(producto);

            if (edito)
            {
                await Swal.FireAsync("Feliciddade", "Producto Guardado", SweetAlertIcon.Success);
            }
            else
            {
                await Swal.FireAsync("Eroor", "No se pudo Guardar el producto", SweetAlertIcon.Error);

            }
            navigationManager.NavigateTo("/Productos"); //Devuelve a la ruta de productos
        }

        //METODO DE CANCELAR
        protected async Task Cancelar()
        {
            navigationManager.NavigateTo("/Productos"); //Devuelve a la ruta de productos
        }

        //METODO DE ELIMINAR
        protected async Task Eliminar()
        {
            bool elimino = false;
            SweetAlertResult result = await Swal.FireAsync(new SweetAlertOptions
            {
                //Mostrara una ventana de alerta 
                Title = "¿Esta Seguro que desea eliminar el producto?",
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true,
                ConfirmButtonText = "Aceptar",
                CancelButtonText = "Cancelar"
            });

            if (!string.IsNullOrEmpty(result.Value)) //validar si esta vacio
            {
                elimino = await productoServicio.EliminarAsync(producto.Codigo);

                if (elimino)
                {
                    await Swal.FireAsync("Excelente", "Producto Eliminado", SweetAlertIcon.Success);
                    navigationManager.NavigateTo("/Productos"); //Nos devuelve a la pantalla de productos
                }
                else
                {
                    await Swal.FireAsync("Error", "No se pudo eliminar el producto", SweetAlertIcon.Error);
                }
            }

        }
    }
}
