using Microsoft.EntityFrameworkCore;
using RestauranteApi.Core.Domain.Common;
using RestauranteApi.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteApi.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<Plato> Plato { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellation = new CancellationToken())
        {
            foreach (var item in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (item.State)
                {
                    case EntityState.Added:
                        item.Entity.created = DateTime.Now;
                        item.Entity.createdBy = "Laihusmanguplus";
                        break;

                    case EntityState.Modified:
                        item.Entity.modifiedAt = DateTime.Now;
                        item.Entity.modifiedBy = "Laihusmanguplus";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellation);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Nombres(tablas)
            modelBuilder.Entity<Orden>().ToTable("Ordenes");
            modelBuilder.Entity<Mesa>().ToTable("Mesas");
            modelBuilder.Entity<Plato>().ToTable("Platos");
            modelBuilder.Entity<Ingrediente>().ToTable("Ingredientes");

            #endregion

            #region "Primary Keys"
            modelBuilder.Entity<Orden>().HasKey(product => product.id);
            modelBuilder.Entity<Mesa>().HasKey(product => product.id);
            modelBuilder.Entity<Plato>().HasKey(product => product.id);
            modelBuilder.Entity<Ingrediente>().HasKey(product => product.id);

            #endregion

            #region Relaciones

            modelBuilder.Entity<Plato>().HasMany<Ingrediente>(plato => plato.Ingredientes).
            WithOne(ingr => ingr.Plato).
            HasForeignKey(ingr => ingr.PlatoID).
            OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Orden>().HasMany<Plato>(orden => orden.Platos).
           WithOne(Plato => Plato.Orden).
           HasForeignKey(Plato => Plato.OrdenID).
           OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Mesa>().HasMany<Orden>(mesa => mesa.Ordenes).
           WithOne(orden => orden.Mesa).
           HasForeignKey(orden => orden.MesaID).
           OnDelete(DeleteBehavior.SetNull);

            #endregion

            #region Config 

            #region Post
            //modelBuilder.Entity<Publicacion>().Property(post => post.id).IsRequired().HasMaxLength(150);
            #endregion

            #endregion
        }
    }
}
