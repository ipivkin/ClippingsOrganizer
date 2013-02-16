using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Data
{
    public interface IRepository
    {
        void Create(string _fileName);
        void Add(Clipping element);
        void Update(Int32 id, Clipping element);
        void Delete(Int32 id);
        List<Clipping> GetAll();
    }
}
