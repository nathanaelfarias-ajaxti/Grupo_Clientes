﻿// <auto-generated />
using GrupoClientes.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GrupoClientes.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GrupoClientes.Models.Grupo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Grupos");
                });

            modelBuilder.Entity("GrupoClientes.Models.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("GrupoClientes.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("GrupoMenu", b =>
                {
                    b.Property<int>("ListaDeGruposId")
                        .HasColumnType("int");

                    b.Property<int>("ListaDeMenusId")
                        .HasColumnType("int");

                    b.HasKey("ListaDeGruposId", "ListaDeMenusId");

                    b.HasIndex("ListaDeMenusId");

                    b.ToTable("GrupoMenu");
                });

            modelBuilder.Entity("GrupoUsuario", b =>
                {
                    b.Property<int>("ListaDeGruposId")
                        .HasColumnType("int");

                    b.Property<int>("ListaDeUsuariosId")
                        .HasColumnType("int");

                    b.HasKey("ListaDeGruposId", "ListaDeUsuariosId");

                    b.HasIndex("ListaDeUsuariosId");

                    b.ToTable("GrupoUsuario");
                });

            modelBuilder.Entity("MenuUsuario", b =>
                {
                    b.Property<int>("ListaDeMenusId")
                        .HasColumnType("int");

                    b.Property<int>("ListaDeUsuariosId")
                        .HasColumnType("int");

                    b.HasKey("ListaDeMenusId", "ListaDeUsuariosId");

                    b.HasIndex("ListaDeUsuariosId");

                    b.ToTable("MenuUsuario");
                });

            modelBuilder.Entity("GrupoMenu", b =>
                {
                    b.HasOne("GrupoClientes.Models.Grupo", null)
                        .WithMany()
                        .HasForeignKey("ListaDeGruposId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GrupoClientes.Models.Menu", null)
                        .WithMany()
                        .HasForeignKey("ListaDeMenusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GrupoUsuario", b =>
                {
                    b.HasOne("GrupoClientes.Models.Grupo", null)
                        .WithMany()
                        .HasForeignKey("ListaDeGruposId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GrupoClientes.Models.Usuario", null)
                        .WithMany()
                        .HasForeignKey("ListaDeUsuariosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MenuUsuario", b =>
                {
                    b.HasOne("GrupoClientes.Models.Menu", null)
                        .WithMany()
                        .HasForeignKey("ListaDeMenusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GrupoClientes.Models.Usuario", null)
                        .WithMany()
                        .HasForeignKey("ListaDeUsuariosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
