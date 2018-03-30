using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Barberia.Areas.ApiRest.Models
{
    public class ManagerUsers
    {
        private static string cadena = "Data Source=aed08db.database.windows.net; Initial Catalog=aed182e08; User ID=aed08user; Password=Aed08pas$;";

        

        public bool updateUser(UsersModel user)
        {
            string query = "update AspNetUsers set UserName = @userName, Email = @email, PhoneNumber = @phoneNumber  where id = @id";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                cmd.Parameters.Add("@id", System.Data.SqlDbType.NVarChar).Value = user.id;
                cmd.Parameters.Add("@userName", System.Data.SqlDbType.NVarChar).Value = user.userName;
                cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar).Value = user.email;
                cmd.Parameters.Add("@phoneNumber", System.Data.SqlDbType.NVarChar).Value = user.phoneNumber;
                
                


                int register = cmd.ExecuteNonQuery();

                return (register == 1);
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

       

        public UsersModel returnUser(string id)
        {
            string query = "SELECT id, UserNAme, Email, PhoneNumber FROM AspNetUsers WHERE id = @id";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);
            UsersModel user = new UsersModel();

            try
            {
                conn.Open();
                cmd.Parameters.Add("@id", System.Data.SqlDbType.NVarChar).Value = id;
                SqlDataReader dr = cmd.ExecuteReader();


                if (dr.Read())
                {

                    user.id = dr.GetString(0);
                    user.email = dr.GetString(1);
                    user.userName = dr.GetString(2);
                    user.phoneNumber = dr.GetString(3);
                   
                }


            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return user;
        }


        public List<UsersJoinModel> allUsers()
        {
            string query = "SELECT u.id, u.Email, u.userName, r.RoleId, us.Name FROM AspNetUsers u, AspNetUserRoles r, AspNetRoles us WHERE u.id = r.UserId AND r.RoleId = us.id";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);
            List<UsersJoinModel> user = new List<UsersJoinModel>();

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {


                    user.Add(new UsersJoinModel
                    {

                        id = dr.GetString(0),
                        email = dr.GetString(1),
                        name = dr.GetString(2),
                        idRol = dr.GetString(3),
                        roleName = dr.GetString(4)
                        

                    });

                }

            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return user;
        }


        public bool deleteUser(string id)
        {
            string query = "DELETE FROM AspNetUsers WHERE id = @id";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);



            try
            {
                conn.Open();
                cmd.Parameters.Add("@id", System.Data.SqlDbType.NVarChar).Value = id;
                int res;
                res = cmd.ExecuteNonQuery();

                return (res == 1);

            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }

        }
    }
}