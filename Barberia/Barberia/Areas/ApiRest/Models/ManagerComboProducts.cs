using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Barberia.Areas.ApiRest.Models
{
    public class ManagerComboProducts
    {
        private static string cadena = "Data Source=aed08db.database.windows.net; Initial Catalog=aed182e08; User ID=aed08user; Password=Aed08pas$;";
        public List<ComboProductModel> ComboProduct()
        {

            string query = "SELECT id, name, salePrice, quantity FROM products";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);
            List<ComboProductModel> product = new List<ComboProductModel>();

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {


                    product.Add(new ComboProductModel
                    {

                        id = dr.GetInt32(0),
                        name = dr.GetString(1),
                        salePrice = dr.GetDecimal(2),
                        quantity = dr.GetInt32(3)

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