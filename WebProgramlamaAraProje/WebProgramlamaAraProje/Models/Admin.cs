using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProgramlamaAraProje.Models
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        public string AdminKullaniciAdi { get; set; }
        public string AdminAdi { get; set; }
        public string AdminSoyadi { get; set; }
        public string AdminSifre { get; set; }
       
    }
}
