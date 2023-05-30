using GrupoClientes.Models;
using Microsoft.EntityFrameworkCore;

namespace GrupoClientes.Data
{
    public class Contexto :DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
            
        }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Grupo> Grupo { get; set; }

        public DbSet<Menu> Menu { get; set; }

       // public DbSet<Usuario_Grupos> Usuario_Grupos { get; set; }

        //public DbSet<Grupos_Menu> Grupos_Menu { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Usuario_Grupos>(entity =>
            //{
            //    entity.HasKey(e => new { e.GruposId, e.UsuarioId });
            //});
            //modelBuilder.Entity<Grupos_Menu>(entity =>
            //{
            //    entity.HasKey(e => new { e.GruposId, e.MenuId});
            //});
            //modelBuilder.Entity<Usuario_Grupos>(entity =>
            //{
            //    entity.HasOne(e => e.Usuario)
            //    .WithMany(e => e.Usuario_Grupos)
            //    .HasForeignKey(e => e.UsuarioId);
            //});
            //modelBuilder.Entity<Usuario_Grupos>(entity =>
            //{
            //    entity.HasOne(e => e.Grupos)
            //    .WithMany(e => e.Usuario_Grupos)
            //    .HasForeignKey(e => e.GruposId);
            //});
            //modelBuilder.Entity<Grupos_Menu>(entity =>
            //{
            //    entity.HasOne(e => e.Grupos)
            //    .WithMany(e => e.Grupos_Menu)
            //    .HasForeignKey(e => e.GruposId);
            //});
            //modelBuilder.Entity<Grupos_Menu>(entity =>
            //{
            //    entity.HasOne(e => e.Menu)
            //    .WithMany(e => e.Grupos_Menu)
            //    .HasForeignKey(e => e.MenuId);
            //});


        }

    }
}
