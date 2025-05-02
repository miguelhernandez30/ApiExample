using System.ComponentModel.DataAnnotations;

namespace Actividad1.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public string Telefono { get; set; }
        public string Edad { get; set; }
        public string TipoUser { get; set; }
    }


    public class PensionDto
    {
        [Key]
        public int IdPension { get; set; }
        public string NombrePension { get; set; }
        public string Descripcion { get; set; }
        public int Cupos { get; set; }
        public string Direccion { get; set; }
        public int IdUsuario { get; set; }
    }
    public class AlojamientoDto
    {

        public int IdPension { get; set; }
        public int IdUsuario { get; set; }
    }
    public class PagoDto
    {
        [Key]
        public int IdPago { get; set; }
        public DateTime? FechaPago { get; set; }
        public DateTime? FechaLimite { get; set; }
        public string MetodoPago { get; set; }
        public int IdPension { get; set; }
    }


}
