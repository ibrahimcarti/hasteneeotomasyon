using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ISekreterDal
    {
        void Add(Sekreter sekreter);
        void Update(Sekreter sekreter);
        void Delete(int sekreter_id);
        List<Sekreter> GetAllSekreter();
        //void Add(Doktor doktor);
        //void Update(Doktor doktor);
        //void DeleteDoktor(int doktor_id);
        //List<Doktor> GetAllDoktor();
        //List<Doktor> GetDoktorbyBrans(string brans);
        //void Add(Hasta hasta);
        //void Update(Hasta hasta);
        //void DeleteHasta(int hasta_id);
        //List<Hasta> GetAllHasta();
        //void Add(Randevu randevu);
    }
}
