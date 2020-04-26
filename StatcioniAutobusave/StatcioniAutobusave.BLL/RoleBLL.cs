using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatcioniAutobisave.DAL;
using StatcioniAutobusave.BO;
using StatcioniAutobusave.BO.Interface;


namespace StatcioniAutobusave.BLL
{
    class RoleBLL: IBaseCrud<Role>
    {
        private readonly RoleDAL dal;
        public RoleBLL()
        {
            dal = new RoleDAL();
        }

        public int Add(Role model)
        {
            return dal.Add(model);
        }

        public Role Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Role> GetALl()
        {
            throw new NotImplementedException();
        }

        public int Modify(Role model)
        {
            throw new NotImplementedException();
        }

        public int Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
