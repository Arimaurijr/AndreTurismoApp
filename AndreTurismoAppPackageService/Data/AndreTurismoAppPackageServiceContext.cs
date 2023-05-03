using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndreTurismoAppModels;
using System.Reflection.Metadata;

namespace AndreTurismoAppPackageService.Data
{
    public class AndreTurismoAppPackageServiceContext : DbContext
    {
        public AndreTurismoAppPackageServiceContext (DbContextOptions<AndreTurismoAppPackageServiceContext> options)
            : base(options)
        {
        }

        public DbSet<AndreTurismoAppModels.PackageModel> PackageModel { get; set; } = default!;

        public DbSet<AndreTurismoAppModels.AddressModel> AddressModel { get; set; } = default!;

        public DbSet<AndreTurismoAppModels.HotelModel> HotelModel { get; set; } = default!;

        public DbSet<AndreTurismoAppModels.ClientModel> ClientModel { get; set; } = default!;

        public DbSet<AndreTurismoAppModels.TicketModel> TicketModel { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddressModel>()
                .HasOne(b => b.Cidade)
                 .WithMany()
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<HotelModel>()
                 .HasOne(b => b.Endereco)
                 .WithMany()
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ClientModel>()
                 .HasOne(b => b.Endereco)
                 .WithMany()
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TicketModel>()
                .HasOne(b => b.Destino)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TicketModel>()
               .HasOne(b => b.Origem)
               .WithMany()
               .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<PackageModel>()
                 .HasOne(b => b.Cliente_Pacote)
                 .WithMany()
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PackageModel>()
                 .HasOne(b => b.Hotel_Pacote)
                 .WithMany()
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PackageModel>()
                .HasOne(b => b.Passagem_Pacote)
                 .WithMany()
                 .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
