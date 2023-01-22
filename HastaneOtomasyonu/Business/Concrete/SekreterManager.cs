using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SekreterManager : ISekreterServices
    {
        ISekreterDal _sekreterdal;
        IHastaDal _hastadal;
        IDoktorDal _doktordal;
        IRandevuDal _randevudal;
        
        public SekreterManager(ISekreterDal sekreterdal, IHastaDal hastadal, IDoktorDal doktordal, IRandevuDal randevudal)
        {
            _sekreterdal = sekreterdal;
            _hastadal = hastadal;
            _doktordal = doktordal;
            _randevudal = randevudal;
        }
        public void Add(Sekreter sekreter)
        {
            _sekreterdal.Add(sekreter);
        }

        public void Add(Doktor doktor)
        {
            _doktordal.Add(doktor);
        }

        public void Add(Hasta hasta)
        {
            _hastadal.Add(hasta);
        }

        public void Add(Randevu randevu)
        {
            _randevudal.Add(randevu);
        }

        public void Delete(int sekreter_id)
        {
            _sekreterdal.Delete(sekreter_id);
        }

        public void DeleteDoktor(int doktor_id)
        {
            _doktordal.Delete(doktor_id);
        }

        public void DeleteHasta(int hasta_id)
        {
            _hastadal.Delete(hasta_id);
        }

        public List<Doktor> GetAllDoktor()
        {
            return _doktordal.GetAllDoktor();
        }

        public List<Hasta> GetAllHasta()
        {
            return _hastadal.GetAllHasta();
        }

        public List<Sekreter> GetAllSekreter()
        {
            return _sekreterdal.GetAllSekreter();
        }

        public List<Doktor> GetDoktorbyBrans(string brans)
        {
            return _doktordal.GetDoktorbyBrans(brans);
        }

        public void Update(Sekreter sekreter)
        {
            _sekreterdal.Update(sekreter);
        }

        public void Update(Doktor doktor)
        {
            _doktordal.Update(doktor);
        }

        public void Update(Hasta hasta)
        {
            _hastadal.Update(hasta);
        }
    }
}
