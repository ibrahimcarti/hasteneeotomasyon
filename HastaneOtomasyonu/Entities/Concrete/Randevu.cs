using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Randevu : IEntity
    {
        public int randevu_id { get; set; }
        public int hasta_id { get; set; }
        public DateTime randevu_tarih { get; set; }
        public string randevu_brans { get; set; }
        public int doktor_id { get; set; }
    }
}
