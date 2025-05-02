using System.ComponentModel.DataAnnotations;

namespace Actividad1.Models
{
    public class UsuarioEnPension
    {
        public int idUSUARIO { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Edad { get; set; }
        public int idPENSION { get; set; }
        public string Nombre_Pension { get; set; }
        public DateTime Fecha_Ingreso { get; set; }
        public DateTime Fecha_Salida { get; set; }
        public string Estado_Reservacion { get; set; } 
    }
    public class CantidadPensionadosDto
    {
        [Key]
        public int CantidadPensionados { get; set; }
    }

}
