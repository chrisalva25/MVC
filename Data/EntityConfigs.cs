using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tarea2.Data.Entidades;

namespace Tarea2.Data
{
    public class EntityConfigs
    {
        public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
        {
            public void Configure(EntityTypeBuilder<Usuario> builder)
            {
                builder.HasKey(x => x.Id);
                builder.Property(s=>s.NombreUsuario).HasColumnType("varchar(255)");
        
                
            }
        }

        public class TaxiConfig : IEntityTypeConfiguration<Taxi>
        {
            public void Configure(EntityTypeBuilder<Taxi> builder)
            {
                builder.HasKey(x=>x.Id);
                builder.HasMany(e => e.Registros).WithOne(e => e.Taxi).HasForeignKey(e => e.TaxiId);
            }
        }

        public class RegistroDiarioConfig : IEntityTypeConfiguration<RegistroDiario>
        {
            public void Configure(EntityTypeBuilder<RegistroDiario> builder)
            {
                builder.HasKey(x => x.Id);
                builder.Property(s => s.PagoDueño).HasColumnType("decimal(12,2)");
                builder.Property(s => s.PagoBase).HasColumnType("decimal(12,2)");
                builder.Property(s => s.TotalDia).HasColumnType("decimal(12,2)");
                builder.Property(s => s.Combustible).HasColumnType("decimal(12,2)");
                builder.Property(s => s.Gastos).HasColumnType("decimal(12,2)");
                builder.Property(s => s.PagoConductor).HasColumnType("decimal(12,2)");

            }
        }
        public class RolConfig : IEntityTypeConfiguration<Rol>
        {
            public void Configure(EntityTypeBuilder<Rol> builder)
            {
                builder.HasKey(e => e.Id);
                builder.Property(s => s.Descripcion).HasColumnType("varchar(25)").HasColumnName("Descripcion");
                builder.Property(s => s.Descripcion2).HasColumnType("varchar(25)").HasColumnName("Descripcion2");
                builder.HasMany(a => a.ModulosRoles).WithOne(a => a.Rol).HasForeignKey(c => c.RolId);
                builder.HasMany(a => a.Usuario).WithOne(a => a.Rol).HasForeignKey(c => c.RolId);
            }
        }
        public class ModuloConfig : IEntityTypeConfiguration<Modulo>
        {
            public void Configure(EntityTypeBuilder<Modulo> builder)
            {
                builder.HasKey(e => e.Id);
                builder.Property(s => s.Nombre).HasColumnType("varchar(25)").HasColumnName("Nombre");
                builder.Property(s => s.Metodo).HasColumnType("varchar(25)").HasColumnName("Metodo");
                builder.Property(s => s.Controller).HasColumnType("varchar(25)").HasColumnName("Controller");
                builder.HasMany(a => a.ModulosRoles).WithOne(a => a.Modulo).HasForeignKey(c => c.ModuloId);
            }
        }
        public class ModulosRolesConfig : IEntityTypeConfiguration<ModulosRoles>
        {
            public void Configure(EntityTypeBuilder<ModulosRoles> builder)
            {
                builder.HasKey(e => e.Id);
            }
        }
        public class AgrupadoModulosConfig : IEntityTypeConfiguration<AgrupadoModulos>
        {
            public void Configure(EntityTypeBuilder<AgrupadoModulos> builder)
            {
                builder.HasKey(e => e.Id);
                builder.Property(s => s.Descripcion).HasColumnType("varchar(25)").HasColumnName("Descripcion");
                builder.HasMany(a => a.Modulos).WithOne(a => a.AgrupadoModulos).HasForeignKey(c => c.AgrupadoModulosId);
            }
        }
    }
}
