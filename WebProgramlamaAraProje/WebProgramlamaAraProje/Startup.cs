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
            //BU metot arac�l��yla uygulamam�z�n i�erisinde kullanaca��m�z bile�enlerin ayarlar�n� yapabiliriz.
            //COnfigures Services metodu i�erisinde uygulaman�n kullanca�� servisler eklenir ve konfigure edilir.
            //Servisleriyse belli bir i�i yapmaktan sorumlu kod par�alar�, s�n�flar ya da k�t�phaneler gibi d���nebilirsiniz. 
            //K�saca onlara bile�enler de diyebilirsiniz.

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
            // Bu metot uygulamam�za gelen HTTP isteklerini hangi a�amalardan ge�irecek bir HTTP cevab� olu�turaca��m�z� belirtti�imiz metottur.
            //Startup i�erisinde bu metodun doldurulmas� ve do�ru ayarlanmas� gereklidir.

            app.UseDeveloperExceptionPage(); //Geli�tirici �stisna Sayfas�n� Kullan
            app.UseStatusCodePages(); //Durum kodu sayfalar�n� kullan
            app.UseStaticFiles(); //Statik Dosyalar� Kullan


            app.UseAuthentication(); //Kimlik Do�rulamay� Kullan


            app.UseRouting(); //Y�nlendirmeyi Kullan


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
