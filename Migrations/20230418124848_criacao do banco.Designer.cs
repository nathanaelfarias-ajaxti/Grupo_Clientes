﻿// <auto-generated />
using GrupoClientes.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GrupoClientes.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20230418124848_criacao do banco")]
    partial class criacaodobanco
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GrupoClientes.Models.Grupos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Descricao");

                    b.HasKey("Id");

                    b.ToTable("Grupos");
                });

            modelBuilder.Entity("GrupoClientes.Models.Grupos_Menu", b =>
                {
                    b.Property<int>("GruposId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("MenuId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("GruposId", "MenuId");

                    b.HasIndex("MenuId");

                    b.ToTable("Grupos_Menu");
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
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Descricao");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Url");

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
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Nome");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)")
                        .HasColumnName("Senha");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("GrupoClientes.Models.Usuario_Grupos", b =>
                {
                    b.Property<int>("GruposId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.HasKey("GruposId", "UsuarioId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Usuario_Grupos");
                });

            modelBuilder.Entity("GrupoClientes.Models.Grupos_Menu", b =>
                {
                    b.HasOne("GrupoClientes.Models.Grupos", "Grupos")
                        .WithMany()
                        .HasForeignKey("GruposId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GrupoClientes.Models.Menu", "Menu")
                        .WithMany()
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grupos");

                    b.Navigation("Menu");
                });

            modelBuilder.Entity("GrupoClientes.Models.Usuario_Grupos", b =>
                {
                    b.HasOne("GrupoClientes.Models.Grupos", "Grupos")
                        .WithMany()
                        .HasForeignKey("GruposId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GrupoClientes.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grupos");

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
