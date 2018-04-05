using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Barberia.Areas.ApiRest.Models
{
    public class ManagerEmployees
    {
        private static string cadena = "Data Source=aed08db.database.windows.net; Initial Catalog=aed182e08; User ID=aed08user; Password=Aed08pas$;";

        public bool createEmploye(EmployeesModel employe)
        {

            string query = "INSERT INTO employees VALUES(@name,@firstName,@lastName,@cellPhone)";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                cmd.Parameters.Add("@name", System.Data.SqlDbType.VarChar).Value = employe.name;
                cmd.Parameters.Add("@firstName", System.Data.SqlDbType.VarChar).Value = employe.firstName;
                cmd.Parameters.Add("@lastName", System.Data.SqlDbType.VarChar).Value = employe.lastName;
                cmd.Parameters.Add("@cellPhone", System.Data.SqlDbType.VarChar).Value = employe.cellPhone;
       

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

        public bool updateEmploye(EmployeesModel employe)
        {
            string query = "UPDATE employees SET   name = @name, firts_name = @firstName, last_name = @lastName, cell_phone = @cellPhone WHERE id = @id";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = employe.id;
                cmd.Parameters.Add("@name", System.Data.SqlDbType.VarChar).Value = employe.name;
                cmd.Parameters.Add("@firstName", System.Data.SqlDbType.VarChar).Value = employe.firstName;
                cmd.Parameters.Add("@lastName", System.Data.SqlDbType.VarChar).Value = employe.lastName;
                cmd.Parameters.Add("@cellPhone", System.Data.SqlDbType.VarChar).Value = employe.cellPhone;
                

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

        public EmployeesModel returnEmploye(int id)
        {
            string query = "SELECT * FROM employees WHERE id = @id";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);
            EmployeesModel employe = new EmployeesModel();

            try
            {
                conn.Open();
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                SqlDataReader dr = cmd.ExecuteReader();


                if (dr.Read())
                {

                    employe.id = dr.GetInt32(0);
                    employe.name = dr.GetString(1);
                    employe.firstName = dr.GetString(2);
                    employe.lastName = dr.GetString(3);
                    employe.cellPhone = dr.GetString(4);
                    
                }


            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return employe;
        }


        public List<EmployeesModel> allEmployees()
        {
            string query = "SELECT * FROM employees";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);
            List<EmployeesModel> employe = new List<EmployeesModel>();

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {


                    employe.Add(new EmployeesModel
                    {

                        id = dr.GetInt32(0),
                        name = dr.GetString(1),
                        firstName = dr.GetString(2),
                        lastName = dr.GetString(3),
                        cellPhone = dr.GetString(4),
                       

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
            return employe;
        }


        public bool deleteEmploye(int id)
        {
            string query = "DELETE FROM employees WHERE id = @id";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);



            try
            {
                conn.Open();
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
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