using Barberia.Areas.ApiRest.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Barberia.Areas.ApiRest.Models
{
    public class ManagerComboService
    {
        private static string cadena = "Data Source=aed08db.database.windows.net; Initial Catalog=aed182e08; User ID=aed08user; Password=Aed08pas$;";
        public List<ComboServiceModel> ComboService()
        {

            string query = "SELECT id,name FROM servicesCatalog";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);
            List<ComboServiceModel> service = new List<ComboServiceModel>();

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {


                    service.Add(new ComboServiceModel
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
            return service;

        }
    }
}