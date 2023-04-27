using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndreTurismoAppModels;

namespace AndreTurismoApp.AddressService.Data
{
    public class AndreTurismoAppAddressServiceContext : DbContext
    {
        public AndreTurismoAppAddressServiceContext (DbContextOptions<AndreTurismoAppAddressServiceContext> options)
            : base(options)
        {
        }

        public DbSet<AndreTurismoAppModels.AddressModel> AddressModel { get; set; } = default!;
    }
}
