using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProgramlamaAraProje.Models
{
    public class CollageRepository : ICollageRepository
    {
        private CollageDbContext context;
        public CollageRepository(CollageDbContext _context)
        {
            context = _context;
        }
        public IQueryable<Announcement> Announcements => context.Announcements;

        public IQueryable<Admin> Admins => context.Admins;

        public void AddAnnouncement(Announcement a) => context.Announcements.Add(a);

        public CollageDbContext GetContext() => context; 
    }
}
