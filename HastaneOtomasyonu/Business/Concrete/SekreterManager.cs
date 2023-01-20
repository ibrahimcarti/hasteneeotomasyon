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
        public SekreterManager(ISekreterDal sekreterdal)
        {
            _sekreterdal = sekreterdal;
        }
        public void Add(Sekreter sekreter)
        {
            _sekreterdal.Add(sekreter);
        }

        public void Delete(int sekreter_id)
        {
            _sekreterdal.Delete(sekreter_id);
        }

        public List<Sekreter> GetAllSekreter()
        {
            return _sekreterdal.GetAllSekreter();
        }

        public void Update(Sekreter sekreter)
        {
            _sekreterdal.Update(sekreter);
        }

    }
}
