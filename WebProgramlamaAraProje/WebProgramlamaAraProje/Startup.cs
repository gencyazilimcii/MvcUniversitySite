using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProgramlamaAraProje.Models;

namespace WebProgramlamaAraProje
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //BU metot aracýlýðyla uygulamamýzýn içerisinde kullanacaðýmýz bileþenlerin ayarlarýný yapabiliriz.
            //COnfigures Services metodu içerisinde uygulamanýn kullancaðý servisler eklenir ve konfigure edilir.
            //Servisleriyse belli bir iþi yapmaktan sorumlu kod parçalarý, sýnýflar ya da kütüphaneler gibi düþünebilirsiniz. 
            //Kýsaca onlara bileþenler de diyebilirsiniz.

            services.AddControllersWithViews();

            services.AddDbContext<CollageDbContext>(opts => {
                opts.UseSqlServer(
                    Configuration["ConnectionStrings:CollageConnection"]);
            });
            services.AddScoped<ICollageRepository, CollageRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Bu metot uygulamamýza gelen HTTP isteklerini hangi aþamalardan geçirecek bir HTTP cevabý oluþturacaðýmýzý belirttiðimiz metottur.
            //Startup içerisinde bu metodun doldurulmasý ve doðru ayarlanmasý gereklidir.

            app.UseDeveloperExceptionPage(); //Geliþtirici Ýstisna Sayfasýný Kullan
            app.UseStatusCodePages(); //Durum kodu sayfalarýný kullan
            app.UseStaticFiles(); //Statik Dosyalarý Kullan


            app.UseAuthentication(); //Kimlik Doðrulamayý Kullan


            app.UseRouting(); //Yönlendirmeyi Kullan


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();

                endpoints.MapControllerRoute(
                    name: "Delete",
                    pattern: "{cotroller=Home}/{action=Delete}/{anoID?}");
                
                endpoints.MapControllerRoute(
                   name: "Admin",
                   pattern: "{cotroller=Home}/{action=Admin}/{username?}");

            });

            //LoginPOST(string username, string password)
        }
    }
}
