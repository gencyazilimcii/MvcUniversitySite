using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProgramlamaAraProje.Models
{
    public class Announcement
    {
        [Key]
        public int DuyuruID { get; set; }
        public string DuyuruBaslik { get; set; }
        public string DuyuruIcerik { get; set; }
        public DateTime? DuyuruTarih { get; set; }
        
    }
}
