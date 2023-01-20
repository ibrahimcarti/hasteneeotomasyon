using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Sekreter :IEntity
    {
        public int sekreter_id { get; set; }
        public string sekreter_adi { get; set; }
        public string sekreter_soyadi { get; set; }
        public string sekreter_tel { get; set; }
    }
}
