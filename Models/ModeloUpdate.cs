namespace Actividad1.Models
{
    public class ActualizarReserva
    {
        public int IdAlojamiento { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public DateTime? FechaSalida { get; set; }
    }

    public class ActualizarReservaDenegado
    {
        public int IdAlojamiento { get; set; }
    }
   

}
