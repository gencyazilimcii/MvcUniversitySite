using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProgramlamaAraProje.Models
{
    public class CollageDbContext: DbContext 
    {
        public CollageDbContext(DbContextOptions<CollageDbContext> options)
            : base(options) { }

        public DbSet<Announcement> Announcements { get; set; } 
        public DbSet<Admin> Admins { get; set; } 

    }
}
