using Microsoft.EntityFrameworkCore;
using Tarea2.Data.Entidades;
using static Tarea2.Data.EntityConfigs;

namespace Tarea2.Data
{
    public class Tarea2DBContext : DbContext
    {
        public Tarea2DBContext(DbContextOptions<Tarea2DBContext> options) : base(options) { }

        public DbSet<RegistroDiario> RegistrosDiarios { get; set; }

        public DbSet<Taxi> Taxis { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Modulo> Modulo { get; set; }
        public DbSet<AgrupadoModulos> AgrupadoModulos { get; set; }
        public DbSet<ModulosRoles> ModulosRoles { get; set; }






        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfiguration(new RegistroDiarioConfig());
            modelBuilder.ApplyConfiguration(new TaxiConfig());
            modelBuilder.ApplyConfiguration(new UsuarioConfig());
            modelBuilder.ApplyConfiguration(new RolConfig());
            modelBuilder.ApplyConfiguration(new ModuloConfig());
            modelBuilder.ApplyConfiguration(new AgrupadoModulosConfig());
            modelBuilder.ApplyConfiguration(new ModulosRolesConfig());


        }
    }
}
