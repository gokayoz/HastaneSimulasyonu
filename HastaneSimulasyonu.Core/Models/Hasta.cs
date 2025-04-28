using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaneSimulasyonu.Core.Models
{
    public class Hasta
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public DateTime DogumTarihi { get; set; }
        public List<Randevu> Randevular { get; set; }
    }
}