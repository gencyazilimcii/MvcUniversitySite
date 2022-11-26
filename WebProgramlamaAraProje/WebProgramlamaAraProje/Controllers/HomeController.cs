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
    public class HomeController : Controller
    {
        private ICollageRepository repository;

        public HomeController(ICollageRepository repo)
        {
            repository = repo;
        }
       
        public IActionResult Index()
        {
            return View();
        }




      
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Admin()
        {
            return View(repository.Announcements);
        }

        public IActionResult Delete(Announcement a)
        {
            // İşlemleri yapar

            return Admin();
        }

        [HttpGet]
        public IActionResult NewAnnouncement()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewAnnouncement(Announcement a)
        {
            if (ModelState.IsValid)
            {
                a.DuyuruTarih = DateTime.Now;
                repository.AddAnnouncement(a);
                repository.GetContext().SaveChanges();

                // Başarılı olursa
                return Admin();
            }
            else
            {
                //// Hata alınırsa
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
