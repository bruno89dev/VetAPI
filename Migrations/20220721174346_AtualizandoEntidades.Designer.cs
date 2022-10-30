﻿// <auto-generated />
using System;
using GftPetCare.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GftPetCare.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220721174346_AtualizandoEntidades")]
    partial class AtualizandoEntidades
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("GftPetCare.Models.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("AlturaEmCm")
                        .HasColumnType("double");

                    b.Property<int>("AnoDeNascimento")
                        .HasColumnType("int");

                    b.Property<string>("Genero")
                        .HasColumnType("longtext");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<double>("Peso")
                        .HasColumnType("double");

                    b.Property<string>("Raca")
                        .HasColumnType("longtext");

                    b.Property<bool>("RegistroAtivo")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("TutorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TutorId");

                    b.ToTable("Animais");
                });

            modelBuilder.Entity("GftPetCare.Models.Atendimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("AlturaEmCmAtual")
                        .HasColumnType("double");

                    b.Property<int?>("AnimalId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataDoAtendimento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Diagnostico")
                        .HasColumnType("longtext");

                    b.Property<string>("ObservacoesGerais")
                        .HasColumnType("longtext");

                    b.Property<double>("PesoAtual")
                        .HasColumnType("double");

                    b.Property<bool>("RegistroAtivo")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("TutorId")
                        .HasColumnType("int");

                    b.Property<int?>("VeterinarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.HasIndex("TutorId");

                    b.HasIndex("VeterinarioId");

                    b.ToTable("Atendimentos");
                });

            modelBuilder.Entity("GftPetCare.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<bool>("RegistroAtivo")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Senha")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("GftPetCare.Models.Veterinario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DocIdentificacao")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Especialidade")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<bool>("RegistroAtivo")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Senha")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Veterinarios");
                });

            modelBuilder.Entity("GftPetCare.Models.Animal", b =>
                {
                    b.HasOne("GftPetCare.Models.Cliente", "Tutor")
                        .WithMany()
                        .HasForeignKey("TutorId");

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("GftPetCare.Models.Atendimento", b =>
                {
                    b.HasOne("GftPetCare.Models.Animal", "Animal")
                        .WithMany()
                        .HasForeignKey("AnimalId");

                    b.HasOne("GftPetCare.Models.Cliente", "Tutor")
                        .WithMany()
                        .HasForeignKey("TutorId");

                    b.HasOne("GftPetCare.Models.Veterinario", "Veterinario")
                        .WithMany()
                        .HasForeignKey("VeterinarioId");

                    b.Navigation("Animal");

                    b.Navigation("Tutor");

                    b.Navigation("Veterinario");
                });
#pragma warning restore 612, 618
        }
    }
}
