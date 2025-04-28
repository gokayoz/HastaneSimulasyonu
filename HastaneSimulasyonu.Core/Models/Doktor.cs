using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaneSimulasyonu.Core.Models
{
    public class Doktor
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public int BolumId { get; set; }
        public Bolum Bolum { get; set; }
        public string Telefon { get; set; }
        public List<Randevu> Randevular { get; set; }
    }
}