using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Barberia.Areas.ApiRest.Models
{
    public class ManagerComboEmployees
    {
        private static string cadena = "Data Source=aed08db.database.windows.net; Initial Catalog=aed182e08; User ID=aed08user; Password=Aed08pas$;";
        public List<ComboEmployeesModel> ComboEmployees()
        {

            string query = "SELECT id, name +' ' + firts_name FROM employees";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);
            List<ComboEmployeesModel> employees = new List<ComboEmployeesModel>();

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {


                    employees.Add(new ComboEmployeesModel
                    {

                        id = dr.GetInt32(0),
                        name = dr.GetString(1),

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
            return employees;

        }
    }
}