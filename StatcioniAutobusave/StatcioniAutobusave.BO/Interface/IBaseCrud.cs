using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatcioniAutobusave.BO
{
  public  interface IBaseCrud<T>
    {
        int Add(T model);
        int Modify(T model);
        int Remove(int id);
        T Get(int id);
        List<T> GetALl();
    }
}
