using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatcioniAutobusave.BO;
using StatcioniAutobisave.DAL;

namespace StatcioniAutobusave.BLL
{
   public  class AdministrationBLL
    {
        private readonly RoleDAL roleDAL;
        private readonly UserDAL userDAL;

        public AdministrationBLL()
        {
            roleDAL = new RoleDAL();
            userDAL = new UserDAL();
        }
        public User userlogin(string username ,string pasword)
        {
            return userDAL.Login(username, pasword);
        }
        public Role GetRole(int id)
        {
            return roleDAL.Get(id);
        }
        public User GetAllUsers()
        {
            User user = new User();
            user.Role = roleDAL.Get(user.Id);
            return user;

        }
    }
}
