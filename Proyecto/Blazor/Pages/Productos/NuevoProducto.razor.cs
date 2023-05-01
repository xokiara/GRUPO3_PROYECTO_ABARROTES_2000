using Blazor.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Modelos;

namespace Blazor.Pages.Productos
{
    public partial class NuevoProducto
    {
        [Inject] private IProductoServicio productoServicio { get; set; } //Inyectamos el servicio
        [Inject] private NavigationManager navigationManager { get; set; } //Objeto de navegacion
        [Inject] private SweetAlertService Swal { get; set; } //Inyectamos el sweetalert

        Producto producto = new Producto(); //Objeto de producto

        string imgUrl = string.Empty; //variable global para la foto

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

            Producto productoExistente = new Producto();

            productoExistente = await productoServicio.GetPorCodigoAsync(producto.Codigo); //llama el metodo para traer producto mediante codigo
            //VALIDACION SI PRODUCTO TIENE MISMO CODIGO
            if (productoExistente != null)
            {
                if (!string.IsNullOrEmpty(productoExistente.Codigo))
                {
                    await Swal.FireAsync("Advertencia", "Ya existe un producto con el mismo código", SweetAlertIcon.Warning); //Alerta
                    return; //Cancela que la ejercucion continue
                }
            }

            bool inserto = await productoServicio.NuevoAsync(producto);

            if (inserto)
            {
                await Swal.FireAsync("Felicidades", "Producto Guardado", SweetAlertIcon.Success);
                navigationManager.NavigateTo("/Productos"); //Nos devuelve a la ruta de productos
            }
            else
            {
                await Swal.FireAsync("Error", "No se pudo Guardar el producto", SweetAlertIcon.Error);
            }
        }

        //METODO DE CANCELAR
        protected async Task Cancelar()
        {
            navigationManager.NavigateTo("/Productos"); //Nos devuelve a la ruta de productos
        }
    }
}
