using Actividad1.Context;
//using Actividad1.Entity;
using Actividad1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Actividad1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioAdminDtoesController : ControllerBase
    {
        private readonly ContextDB _context;

        public UsuarioAdminDtoesController(ContextDB context)
        {
            _context = context;
        }

        [HttpPost("PensionAdmin")]
        public async Task<IActionResult> PostUsuarioAdminDto(PensionDto pension)
        {
            try
            {
                await _context.Database.ExecuteSqlInterpolatedAsync(
                    $"CALL RegistrarPensionSiEsAdmin({pension.IdPension}, {pension.NombrePension}, {pension.Descripcion}, {pension.Cupos}, {pension.Direccion}, {pension.IdUsuario})"
                );

                return Ok("Registrado correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al insertar: {ex.Message}");
            }
        }

        [HttpPost("RegistrarUsuario")]
        public async Task<IActionResult> PostUsuarioAdminDto(Usuario usuario)
        {
            try
            {

                await _context.Database.ExecuteSqlInterpolatedAsync(
                    $"CALL RegistrarUsuario({usuario.IdUsuario}, {usuario.Nombre}, {usuario.Correo}, {usuario.Contraseña}, {usuario.Telefono}, {usuario.Edad}, {usuario.TipoUser})"
                );

                return Ok("Registrado correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al consultar: {ex.Message}");
            }
        }


        [HttpPost("PedirCupo")]
        public async Task<IActionResult> PostPedirCupoPensionDto(AlojamientoDto alojamientoDto)
        {
            try
            {
                // Usamos CALL en lugar de EXEC para MySQL
                await _context.Database.ExecuteSqlInterpolatedAsync(
                    $"CALL RegistrarAlojamientoPendiente({alojamientoDto.IdPension}, {alojamientoDto.IdUsuario})"
                );

                return Ok("Registrado correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar: {ex.Message}");
            }
        }

        [HttpPost("Pago")]
        public async Task<IActionResult> PagoEfectivo(PagoDto pagoEfectivo)
        {
            try
            {
                // Usamos CALL en lugar de EXEC para MySQL
                await _context.Database.ExecuteSqlInterpolatedAsync(
                    $"CALL RegistrarPago({pagoEfectivo.IdPago}, {pagoEfectivo.FechaPago}, {pagoEfectivo.FechaLimite}, {pagoEfectivo.MetodoPago}, {pagoEfectivo.IdPension})"
                );

                return Ok("Registrado correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar: {ex.Message}");
            }
        }


        //[HttpPut("ActualizarReservaAceptada")]
        //public async Task<IActionResult> ActualizarReserAcept(ActualizarReserva reserva)
        //{
        //    try
        //    {
        //        var parametros = new[]
        //        {
        //     new SqlParameter("@idAlojamiento", reserva.IdAlojamiento),
        //     new SqlParameter("@FechaIngreso", reserva.FechaIngreso ?? (object)DBNull.Value),
        //     new SqlParameter("@FechaSalida", reserva.FechaSalida ?? (object)DBNull.Value)

        //};
        //        await _context.Database.ExecuteSqlRawAsync("EXEC ActualizarReservaAceptada @idAlojamiento, @FechaIngreso, @FechaSalida", parametros);

        //        return Ok("Reserva actualizada a Aceptada correctamente");
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Error al actualizar: {ex.Message}");
        //    }
        //}
        //[HttpPut("ActualizarReservaDenegada")]
        //public async Task<IActionResult> ActualizarReserDenegado(ActualizarReservaDenegado reserva)
        //{
        //    try
        //    {
        //        var parametros = new[]
        //        {
        //          new SqlParameter("@idAlojamiento", reserva.IdAlojamiento),
        //};
        //        await _context.Database.ExecuteSqlRawAsync("EXEC ActualizarReservaRechazada @idAlojamiento", parametros);

        //        return Ok("Reserva actualizada a Denegado correctamente");
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Error al actualizar: {ex.Message}");
        //    }
        //}


         

        //[HttpGet("CantidadPensionados/{idAdmin}")]
        //public async Task<ActionResult<int>> ObtenerCantidadPensionados(int idAdmin)
        //{
        //    try
        //    {   
        //        var idAdminParam = new SqlParameter("@IdUsuario", idAdmin);

        //        var resultado = await _context.CantidadPensionadosDto
        //            .FromSqlRaw("EXEC ContarPensionesDeAdmin @IdUsuario", idAdminParam)
        //            .ToListAsync();

        //        if (resultado.Count == 0)
        //            return NotFound("No se encontraron pensionados para este administrador.");

        //        return Ok(resultado.First().CantidadPensionados);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Error al consultar: {ex.Message}");
        //    }
        //}
        //[HttpGet("ClientesPensionados")]
        //public async Task<ActionResult<IEnumerable<UsuarioEnPension>>> GetClientesPensionados()
        //{
        //    try
        //    {
        //        // Ejecutamos el procedimiento almacenado para obtener los clientes pensionados
        //        var clientesPensionados = await _context.Set<UsuarioEnPension>().FromSqlRaw("EXEC BuscarClientesPensionados").ToListAsync();

        //        // Si no hay clientes pensionados
        //        if (clientesPensionados == null || !clientesPensionados.Any())
        //        {
        //            return NotFound("No hay clientes pensionados.");
        //        }

        //        return Ok(clientesPensionados);
        //    }
        //    catch (Exception ex)
        //    {
                
        //        return StatusCode(500, $"Error al obtener clientes pensionados: {ex.Message}");
        //    }
        //}
    }
}
