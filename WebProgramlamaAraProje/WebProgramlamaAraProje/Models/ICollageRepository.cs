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
        void DeleteAnnouncement(int? id);
        void UpdateAnnouncement(Announcement ano);
        Announcement FindAnnouncement(int? anoID);
        Admin FindAdmin(int? adminID);
        void Save();
    }
}
