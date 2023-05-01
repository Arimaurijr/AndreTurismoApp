using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndreTurismoAppModels;

namespace AndreTurismoAppTicketService.Data
{
    public class AndreTurismoAppTicketServiceContext : DbContext
    {
        public AndreTurismoAppTicketServiceContext (DbContextOptions<AndreTurismoAppTicketServiceContext> options)
            : base(options)
        {
        }

        public DbSet<AndreTurismoAppModels.TicketModel> TicketModel { get; set; } = default!;
    }

   /*
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TicketModel>().HasOne(p => p.Origem).WithOne().HasForeignKey<TicketModel>("OrigemId").OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<TicketModel>().HasOne(p => p.Destino).WithOne().HasForeignKey<TicketModel>("DestinoId").OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<TicketModel>().HasOne(p => p.Cliente).WithOne().HasForeignKey<TicketModel>("ClienteId").OnDelete(DeleteBehavior.NoAction);
    }
   */
    
}
