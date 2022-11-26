using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebProgramlamaAraProje.Models;

namespace WebProgramlamaAraProje.Controllers
{
    public struct AdminStack
    {
        public Admin admin;
        public IQueryable<Announcement> announcements;
    }

    public class HomeController : Controller
    {
        private ICollageRepository repository;

        public HomeController(ICollageRepository c)
        {
            repository = c;
        }
       
        public IActionResult Index()
        {
            CurrentAdmin = null;

            return View();
        }

        public IActionResult LogOut()
        {
            return RedirectToAction("Index");
        }

        public IActionResult Login()
        {
            return View();
        }

        Admin CurrentAdmin = null;

        public IActionResult LoginPOST(string username, string password)
        {
            Admin admin = null;
            
            try
            {
                admin = repository.Admins.Where(i => i.AdminKullaniciAdi == username).First();
            }
            catch (Exception)
            {

            }

            if (admin == null) return RedirectToAction("Login");

            if (admin.AdminSifre == password)
            {
                CurrentAdmin = admin;
                return RedirectToAction("Admin", admin);
            }
                
            else return RedirectToAction("Login");
        }

        public IActionResult Admin(Admin a)
        {
            AdminStack temp = new AdminStack { admin = a, announcements = repository.Announcements};

            return View(temp);
        }

        public IActionResult Delete(int? anoID)
        {
            if (repository.Announcements.Any(x => x.DuyuruID == anoID))
            {
                if (anoID == null)
                    return RedirectToAction("Admin");

                repository.DeleteAnnouncement(anoID);
                repository.Save();

                //Silme İşlemi Başarılı
            }

            return RedirectToAction("Admin");
        }

        // GET
        public IActionResult UpdateAnnouncement(int? anoID)
        {
            if (anoID == null)
                return NotFound();

            var ano = repository.FindAnnouncement(anoID);

            if (ano == null) return NotFound();

            return View(ano);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateAnnouncement(Announcement ano)
        {
            if (ModelState.IsValid)
            {
               // ano.DuyuruTarih = repository.FindAnnouncement(ano.DuyuruID).DuyuruTarih;
                repository.UpdateAnnouncement(ano);
                repository.Save();

                return RedirectToAction("Admin");
            }
            else
            {
                return RedirectToAction("NewAnnouncement");
            }
        }

        [HttpGet]
        public IActionResult NewAnnouncement()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewAnnouncement(Announcement a)
        {
            if (ModelState.IsValid)
            {
                // Başarılı olursa

                a.DuyuruTarih = DateTime.Now;
                repository.AddAnnouncement(a);
                repository.Save();

                return RedirectToAction("Admin");
            }
            else
            {
                //Verilen değerler yanlışsa

                return View();
            }
        }

        public IActionResult Announcement()
        {
            return View(repository.Announcements);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
