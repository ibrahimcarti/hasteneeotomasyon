using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IHastaDal
    {
        void Add(Hasta hasta);
        void Update(Hasta hasta);
        void Delete(int hasta_id);
        List<Hasta> GetAllHasta();
    }
}
