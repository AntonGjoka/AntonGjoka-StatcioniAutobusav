using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace StatcioniAutobusave.BO.Interface
{
   public interface IConverttoobject<T> where T:class
    {
        T toObject(SqlDataReader reader);
    }
}
