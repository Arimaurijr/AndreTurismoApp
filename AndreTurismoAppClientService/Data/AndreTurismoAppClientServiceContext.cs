using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndreTurismoAppModels;

namespace AndreTurismoAppClientService.Data
{
    public class AndreTurismoAppClientServiceContext : DbContext
    {
        public AndreTurismoAppClientServiceContext (DbContextOptions<AndreTurismoAppClientServiceContext> options)
            : base(options)
        {
        }

        public DbSet<AndreTurismoAppModels.ClientModel> ClientModel { get; set; } = default!;
    }
}
