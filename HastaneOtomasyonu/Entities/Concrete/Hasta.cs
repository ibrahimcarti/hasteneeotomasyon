using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Hasta : IEntity
    {
        public int hasta_id { get; set; }
        public string hasta_adi { get; set; }
        public string hasta_soyadi { get; set; }
        public string hasta_tel { get; set; }
        public string hasta_gittigibolum { get; set; }
    }
}
