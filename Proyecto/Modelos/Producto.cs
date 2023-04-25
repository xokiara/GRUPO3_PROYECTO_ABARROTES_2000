using System.ComponentModel.DataAnnotations;

namespace Modelos
{
    public class Producto
    {
        //PROPIEDADES
        [Required(ErrorMessage = "El Código es Obligatorio")] //Mensaje de error del Campo Codigo es abligatorio
        public string Codigo { get; set; }
        [Required(ErrorMessage = "La Descripción es Obligatoria")] ////Mensaje de error del Campo Descripcion es abligatorio
        public string Descripcion { get; set; }
        public int Existencia { get; set; }
        public decimal Precio { get; set; }
        public byte[] Foto { get; set; }
        public bool EstaActivo { get; set; }

    }
}
