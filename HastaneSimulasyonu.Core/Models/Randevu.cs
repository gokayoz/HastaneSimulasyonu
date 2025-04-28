using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaneSimulasyonu.Core.Models
{
    public class Randevu
    {
        public int Id { get; set; }
        public int HastaId { get; set; }
        public int DoktorId { get; set; }
        public DateTime Tarih { get; set; }
        public Hasta Hasta { get; set; }
        public Doktor Doktor { get; set; }
    }
}