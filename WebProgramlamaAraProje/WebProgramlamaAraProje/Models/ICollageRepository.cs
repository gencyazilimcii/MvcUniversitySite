using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProgramlamaAraProje.Models
{
    public interface ICollageRepository
    {
        IQueryable<Announcement> Announcements { get; }
        IQueryable<Admin> Admins { get; }

        void AddAnnouncement(Announcement a);
        CollageDbContext GetContext();
    }
}
