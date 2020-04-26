using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatcioniAutobusave.BO;
using StatcioniAutobusave.BO.Interface;


namespace StatcioniAutobisave.DAL
{
    public class RoleDAL : IBaseCrud<Role>,IConverttoobject<Role>


    {
        //public string _connectionString = "Server=NOTI-TONI\\SQL;Database=Statcioni i autobusave;";
        public string connectionString = ConfigurationManager.ConnectionStrings["BusStationManagment"].ConnectionString;
        public int Add(Role model)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("dbo.usp_Role_Insert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("RoleName", model.Name);

                command.Parameters.AddWithValue("Description", model.Description);
                int rowaffected = command.ExecuteNonQuery();
                command.Dispose();
                command.Clone();
                connection.Dispose();
                return rowaffected;

            }
            catch ( Exception e)
            {
                return -1;
            }
        }

        public Role Get(int id)
        {
            try
            {
                Role role = null;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("usp_Roles_GetById", connection))
                    {
                        command.Parameters.AddWithValue("RoleID", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                // role = new Role();
                                //role.ID = int.Parse(reader["ID"].ToString());
                                //role.Name = reader["Name"].ToString();
                                //if (reader["Description"] != null)
                                //{
                                //    role.Description = reader["Descripton"].ToString();

                                //}
                                role = toObject(reader);
                               

                            }
                        }
                    }
                    return role;

                }
            }
            catch (Exception)
            {
                return null;
            }

        }

        public List<Role> GetALl()
        {
            using (SqlConnection connection=new SqlConnection(connectionString))
            {
                try
                {
                    List<Role> result = null;
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("usp_Roles_GetAll", connection))
                    {
                       
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            result = new List<Role>();
                            while (reader.Read())
                            {
                                
                                //Role role = new Role();
                                //role.ID = int.Parse(reader["ID"].ToString());
                                //role.Name = reader["Name"].ToString();
                                //if (reader["Description"] != null)
                                //{
                                //    role.Description = reader["Descripton"].ToString();

                                //}
                                result.Add(toObject(reader));

                            }
                        }
                    }
                    return result;

                }
                catch (Exception)
                {
                    return null;
                }
            }
            
        }

        public int Modify(Role model)
        {
            throw new NotImplementedException();
        }

        public int Remove(int id)
        {
            using (var connection=SqlHelper.GetConnection())
            {
                using (var command = SqlHelper.Command(connection,"dbo.usp_Role_RemovebyId",CommandType.StoredProcedure))
                {
                    command.Parameters.AddWithValue("id", id);
                    int result = command.ExecuteNonQuery();
                    return result;
                }
            }
        }

        public Role toObject(SqlDataReader reader)
        {
            Role role = new Role();
            role.ID = int.Parse(reader["ID"].ToString());
            role.Name = reader["Name"].ToString();
            if (reader["Description"] != null)
            
                role.Description = reader["Descripton"].ToString();


            return role;
        }
    }
}
