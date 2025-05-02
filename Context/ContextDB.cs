//using Actividad1.Entity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Actividad1.Models;
namespace Actividad1.Context

{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions<ContextDB> options) : base(options)
        {
        }

        public DbSet<CantidadPensionadosDto> CantidadPensionadosDto { get; set; }
    }

}
