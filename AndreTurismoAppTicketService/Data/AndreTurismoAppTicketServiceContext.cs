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


        public DbSet<AndreTurismoAppModels.AddressModel> AddressModel { get; set; } = default!;

        public DbSet<AndreTurismoAppModels.ClientModel> ClientModel { get; set; } = default!;
    }


}
