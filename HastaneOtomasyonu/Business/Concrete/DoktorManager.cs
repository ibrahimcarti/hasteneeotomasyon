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
    public class DoktorManager : IDoktorServices
    {

        IDoktorDal _doktordal;
        ISekreterDal _sekreterdal;
        IHastaDal _hastadal;
        IRandevuDal _randevudal;

        public DoktorManager(ISekreterDal sekreterdal, IHastaDal hastadal, IDoktorDal doktordal, IRandevuDal randevudal)
        {
            _sekreterdal = sekreterdal;
            _hastadal = hastadal;
            _doktordal = doktordal;
            _randevudal = randevudal;
        }
        //public void Add(Doktor doktor)
        //{
        //    _doktordal.Add(doktor);
        //}

        //public void Delete(int doktor_id)
        //{
        //    _doktordal.Delete(doktor_id);
        //}

        //public List<Doktor> GetAllDoktor()
        //{
        //    return _doktordal.GetAllDoktor();
        //}

        //public List<Doktor> GetDoktorbyBrans(string brans)
        //{
        //    return _doktordal.GetDoktorbyBrans(brans);
        //}

        //public void Update(Doktor doktor)
        //{
        //    _doktordal.Update(doktor);
        //}
        public List<Hasta> GetHastabyDoktor(int doktor_id)
        {
            return _doktordal.GetHastabyDoktor(doktor_id);
        }
    }
}
