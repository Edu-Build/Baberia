using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Barberia.Areas.ApiRest.Models
{
    public class ManagerComboTypeProduct
    {
        private static string cadena = "Data Source=aed08db.database.windows.net; Initial Catalog=aed182e08; User ID=aed08user; Password=Aed08pas$;";
        public List<ComboTypeProductModel> ComboType()
        {

            string query = "select * from typeProduct";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);
            List<ComboTypeProductModel> product = new List<ComboTypeProductModel>();

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {


                    product.Add(new ComboTypeProductModel
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