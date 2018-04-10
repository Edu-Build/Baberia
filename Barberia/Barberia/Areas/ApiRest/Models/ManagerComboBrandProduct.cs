using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Barberia.Areas.ApiRest.Models
{
    public class ManagerComboBrandProduct
    {
        private static string cadena = "Data Source=aed08db.database.windows.net; Initial Catalog=aed182e08; User ID=aed08user; Password=Aed08pas$;";
        public List<comboBrandProductModel> ComboBrand()
        {

            string query = "select * from brandProducts";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);
            List<comboBrandProductModel> product = new List<comboBrandProductModel>();

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {


                    product.Add(new comboBrandProductModel
                    {

                        id = dr.GetString(0),
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
            return product;

        }
    }
}