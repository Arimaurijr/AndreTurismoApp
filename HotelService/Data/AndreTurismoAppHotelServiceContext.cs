using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndreTurismoAppModels;

namespace AndreTurismoApp.HotelService.Data
{
    public class AndreTurismoAppHotelServiceContext : DbContext
    {
        public AndreTurismoAppHotelServiceContext (DbContextOptions<AndreTurismoAppHotelServiceContext> options)
            : base(options)
        {
        }

        public DbSet<AndreTurismoAppModels.HotelModel> HotelModel { get; set; } = default!;

        //public DbSet<AndreTurismoAppModels.AddressModel> EnderecoModel { get; set; } = default!;

        public DbSet<AndreTurismoAppModels.AddressModel> AddressModel { get; set; } = default!;
    }
}
