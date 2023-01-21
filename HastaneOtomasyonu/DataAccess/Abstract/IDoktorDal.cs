using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IDoktorDal
    {
        void Add(Doktor doktor);
        void Update(Doktor doktor);
        void Delete(int doktor_id);
        List<Doktor> GetAllDoktor();
    }
}
