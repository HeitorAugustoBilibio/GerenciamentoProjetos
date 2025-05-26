using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Sigma.Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Sigma.Infra.Data.Context
{
    public class SigmaContext : DbContext
    {
        public SigmaContext(DbContextOptions<SigmaContext> options) : base(options) { }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(DateTime))
                    {
                        property.SetValueConverter(new ValueConverter<DateTime, DateTime>(
                            v => DateTime.SpecifyKind(v, DateTimeKind.Utc),
                            v => DateTime.SpecifyKind(v, DateTimeKind.Utc)
                        ));
                    }

                    if (property.ClrType == typeof(DateTime?))
                    {
                        property.SetValueConverter(new ValueConverter<DateTime?, DateTime?>(
                            v => v.HasValue ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : v,
                            v => v.HasValue ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : v
                        ));
                    }

                    property.SetColumnName((property.Name ?? string.Empty).ToLower());
                }

                entityType.SetTableName((entityType.GetTableName() ?? string.Empty).ToLower());

                foreach (var key in entityType.GetKeys())
                {
                    key.SetName((key.GetName() ?? string.Empty).ToLower());
                }

                foreach (var foreignKey in entityType.GetForeignKeys())
                {
                    foreignKey.SetConstraintName((foreignKey.GetConstraintName() ?? string.Empty).ToLower());
                }

                foreach (var index in entityType.GetIndexes())
                {
                    index.SetDatabaseName((index.GetDatabaseName() ?? string.Empty).ToLower());
                }
            }
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
