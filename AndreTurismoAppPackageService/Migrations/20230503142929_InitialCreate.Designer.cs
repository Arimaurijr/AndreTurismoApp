﻿// <auto-generated />
using System;
using AndreTurismoAppPackageService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AndreTurismoAppPackageService.Migrations
{
    [DbContext(typeof(AndreTurismoAppPackageServiceContext))]
    [Migration("20230503142929_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AndreTurismoAppModels.AddressModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CidadeId")
                        .HasColumnType("int");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Data_Cadastro_Endereco")
                        .HasColumnType("datetime2");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CidadeId");

                    b.ToTable("AddressModel");
                });

            modelBuilder.Entity("AndreTurismoAppModels.CityModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Data_Cadastro_Cidade")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CityModel");
                });

            modelBuilder.Entity("AndreTurismoAppModels.ClientModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Data_Cadastro_Cliente")
                        .HasColumnType("datetime2");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("ClientModel");
                });

            modelBuilder.Entity("AndreTurismoAppModels.HotelModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Data_Cadastro_Hotel")
                        .HasColumnType("datetime2");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Valor_Hotel")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("HotelModel");
                });

            modelBuilder.Entity("AndreTurismoAppModels.PackageModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Cliente_PacoteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data_Cadastro_Pacote")
                        .HasColumnType("datetime2");

                    b.Property<int>("Hotel_PacoteId")
                        .HasColumnType("int");

                    b.Property<int>("Passagem_PacoteId")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor_Pacote")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("Cliente_PacoteId");

                    b.HasIndex("Hotel_PacoteId");

                    b.HasIndex("Passagem_PacoteId");

                    b.ToTable("PackageModel");
                });

            modelBuilder.Entity("AndreTurismoAppModels.TicketModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("DestinoId")
                        .HasColumnType("int");

                    b.Property<int>("OrigemId")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor_Passagem")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("DestinoId");

                    b.HasIndex("OrigemId");

                    b.ToTable("TicketModel");
                });

            modelBuilder.Entity("AndreTurismoAppModels.AddressModel", b =>
                {
                    b.HasOne("AndreTurismoAppModels.CityModel", "Cidade")
                        .WithMany()
                        .HasForeignKey("CidadeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Cidade");
                });

            modelBuilder.Entity("AndreTurismoAppModels.ClientModel", b =>
                {
                    b.HasOne("AndreTurismoAppModels.AddressModel", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("AndreTurismoAppModels.HotelModel", b =>
                {
                    b.HasOne("AndreTurismoAppModels.AddressModel", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("AndreTurismoAppModels.PackageModel", b =>
                {
                    b.HasOne("AndreTurismoAppModels.ClientModel", "Cliente_Pacote")
                        .WithMany()
                        .HasForeignKey("Cliente_PacoteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AndreTurismoAppModels.HotelModel", "Hotel_Pacote")
                        .WithMany()
                        .HasForeignKey("Hotel_PacoteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AndreTurismoAppModels.TicketModel", "Passagem_Pacote")
                        .WithMany()
                        .HasForeignKey("Passagem_PacoteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cliente_Pacote");

                    b.Navigation("Hotel_Pacote");

                    b.Navigation("Passagem_Pacote");
                });

            modelBuilder.Entity("AndreTurismoAppModels.TicketModel", b =>
                {
                    b.HasOne("AndreTurismoAppModels.ClientModel", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AndreTurismoAppModels.AddressModel", "Destino")
                        .WithMany()
                        .HasForeignKey("DestinoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AndreTurismoAppModels.AddressModel", "Origem")
                        .WithMany()
                        .HasForeignKey("OrigemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Destino");

                    b.Navigation("Origem");
                });
#pragma warning restore 612, 618
        }
    }
}