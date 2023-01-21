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
        public DoktorManager(IDoktorDal doktordal)
        {
            _doktordal = doktordal;
        }
        public void Add(Doktor doktor)
        {
            _doktordal.Add(doktor);
        }

        public void Delete(int doktor_id)
        {
            _doktordal.Delete(doktor_id);
        }

        public List<Doktor> GetAllDoktor()
        {
            return _doktordal.GetAllDoktor();
        }

        public void Update(Doktor doktor)
        {
            _doktordal.Update(doktor);
        }
    }
}
