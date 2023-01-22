using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDoktorServices
    {
        //void Add(Doktor doktor);
        //void Update(Doktor doktor);
        //void Delete(int doktor_id);
        //List<Doktor> GetAllDoktor();
        //List<Doktor> GetDoktorbyBrans(string brans);
        List<Hasta> GetHastabyDoktor(int doktor_id);
    }
}
