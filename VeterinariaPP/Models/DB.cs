using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace VeterinariaPP.Models
{
    public partial class DB : DbContext
    {
        public DB()
            : base("name=DB")
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Cita> Cita { get; set; }
        public virtual DbSet<Compra> Compra { get; set; }
        public virtual DbSet<DetalleCita> DetalleCita { get; set; }
        public virtual DbSet<DetalleCompra> DetalleCompra { get; set; }
        public virtual DbSet<DetalleVenta> DetalleVenta { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Historial> Historial { get; set; }
        public virtual DbSet<Mascota> Mascota { get; set; }
        public virtual DbSet<Privilegio> Privilegio { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<Servicio> Servicio { get; set; }
        public virtual DbSet<Sintoma> Sintoma { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Venta> Venta { get; set; }
        public virtual DbSet<Veterinaria> Veterinaria { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estado>()
                .HasMany(e => e.Cita)
                .WithOptional(e => e.Estado)
                .HasForeignKey(e => e.IdEstadoCita);

            modelBuilder.Entity<Estado>()
                .HasMany(e => e.Mascota)
                .WithOptional(e => e.Estado)
                .HasForeignKey(e => e.IdEstadoMascota);

            modelBuilder.Entity<Estado>()
                .HasMany(e => e.Producto)
                .WithOptional(e => e.Estado)
                .HasForeignKey(e => e.IdEstadoProducto);

            modelBuilder.Entity<Estado>()
                .HasMany(e => e.Proveedor)
                .WithOptional(e => e.Estado)
                .HasForeignKey(e => e.IdEstadoProveedor);

            modelBuilder.Entity<Estado>()
                .HasMany(e => e.Servicio)
                .WithOptional(e => e.Estado)
                .HasForeignKey(e => e.IdEstadoServicio);

            modelBuilder.Entity<Estado>()
                .HasMany(e => e.Usuario)
                .WithRequired(e => e.Estado)
                .HasForeignKey(e => e.IdEstadoUsuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Estado>()
                .HasMany(e => e.Veterinaria)
                .WithOptional(e => e.Estado)
                .HasForeignKey(e => e.IdEstadoVeterinaria);

            modelBuilder.Entity<Privilegio>()
                .HasMany(e => e.Usuario)
                .WithRequired(e => e.Privilegio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Cita)
                .WithOptional(e => e.Usuario)
                .HasForeignKey(e => e.IdDueño);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Compra)
                .WithOptional(e => e.Usuario)
                .HasForeignKey(e => e.IdEmpleado);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Mascota)
                .WithOptional(e => e.Usuario)
                .HasForeignKey(e => e.IdDueño);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Venta)
                .WithOptional(e => e.Usuario)
                .HasForeignKey(e => e.IdEmpleado);

            modelBuilder.Entity<Veterinaria>()
                .HasMany(e => e.Producto)
                .WithRequired(e => e.Veterinaria)
                .WillCascadeOnDelete(false);
        }
    }
}
