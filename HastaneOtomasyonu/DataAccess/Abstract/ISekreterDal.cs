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
    }
}
