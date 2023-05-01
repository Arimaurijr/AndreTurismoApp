using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndreTurismoAppModels;

namespace AndreTurismoAppPackageService.Data
{
    public class AndreTurismoAppPackageServiceContext : DbContext
    {
        public AndreTurismoAppPackageServiceContext (DbContextOptions<AndreTurismoAppPackageServiceContext> options)
            : base(options)
        {
        }

        public DbSet<AndreTurismoAppModels.PackageModel> PackageModel { get; set; } = default!;
    }
}
