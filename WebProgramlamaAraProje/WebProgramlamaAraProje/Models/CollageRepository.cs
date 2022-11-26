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

        public void DeleteAnnouncement(int? id)
        {
            if (id == null) return;
            context.Announcements.Remove(Announcements.Where(i => i.DuyuruID == id).First());
        }

        public void UpdateAnnouncement(Announcement ano) => context.Announcements.Update(ano);

        public void Save() => context.SaveChanges();

        public Announcement FindAnnouncement(int? anoID) => context.Announcements.Find(anoID);
        public Admin FindAdmin(int? adminID) => context.Admins.Find(adminID);
    }
}
