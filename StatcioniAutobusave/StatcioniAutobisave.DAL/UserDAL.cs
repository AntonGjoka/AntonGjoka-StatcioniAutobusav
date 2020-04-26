using StatcioniAutobusave.BO;
using StatcioniAutobusave.BO.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatcioniAutobisave.DAL
{
    public class UserDAL : IBaseCrud<User>, IConverttoobject<User>
    {
        public int Add(User model)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetALl()
        {
            throw new NotImplementedException();
        }
        public User Login(string username,string password)
        {
            User user = null;
            using (var connection = SqlHelper.GetConnection())
            {
                using (var cmdcomand = SqlHelper.Command(connection, "dbo.ups_Authenticate", System.Data.CommandType.StoredProcedure))
                {
                    cmdcomand.Parameters.AddWithValue("username", username);
                    cmdcomand.Parameters.AddWithValue("password", password);
                    using (var reader= cmdcomand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = toObject(reader);
                        }
                    }
                }
            }
            return user;
        }
        public User toObject(SqlDataReader reader)
        {
            User user = new User();

            user.Id = int.Parse(reader["UsersID"].ToString());
            user.UserName = reader["UserName"].ToString();
            user.Password = reader["UserPass"].ToString();
            user.IsActive = (int)reader["IsActive"];
            user.InsertBy = reader["InsertBy"].ToString();

            return user;

        }

        public int Modify(User model)
        {
            throw new NotImplementedException();
        }

        public int Remove(int id)
        {
            throw new NotImplementedException();
        }

       

    }
}
