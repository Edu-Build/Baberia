using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Barberia.Areas.ApiRest.Models
{
    public class ManagerBuyedProducts
    {
        private static string cadena = "Data Source=aed08db.database.windows.net; Initial Catalog=aed182e08; User ID=aed08user; Password=Aed08pas$;";

        public bool createBuyed(BuyedProductsModel product)
        {

            string query = "INSERT INTO buyedProducts VALUES (@idProduct,@priceBuy,@quantity,GETDATE())";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                cmd.Parameters.Add("@idProduct", System.Data.SqlDbType.Int).Value = product.idProduct;
                cmd.Parameters.Add("@priceBuy", System.Data.SqlDbType.Money).Value = product.priceBuy;
                cmd.Parameters.Add("@quantity", System.Data.SqlDbType.Int).Value = product.quantity;

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

        public bool updateBuyed(BuyedProductsModel product)
        {
            string query = "UPDATE buyedProducts SET idProduct = @idProduct, priceBuy = @priceBuy, quantity = @quantity WHERE id = @id";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = product.id;
                cmd.Parameters.Add("@idProduct", System.Data.SqlDbType.Int).Value = product.idProduct;
                cmd.Parameters.Add("@priceBuy", System.Data.SqlDbType.Money).Value = product.priceBuy;
                cmd.Parameters.Add("@quantity", System.Data.SqlDbType.Int).Value = product.quantity;

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

        public bool deleteProduct(int id)
        {
            string query = "DELETE FROM buyedProducts WHERE id = @id";
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

        public BuyedProductsModel returnBuyed(int id)
        {
            string query = "SELECT idProduct, priceBuy, quantity FROM buyedProducts WHERE id = @id";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);
            BuyedProductsModel product = new BuyedProductsModel();


            try
            {
                conn.Open();
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                SqlDataReader dr = cmd.ExecuteReader();


                if (dr.Read())
                {
                    product.idProduct = dr.GetInt32(0);
                    product.priceBuy = dr.GetDecimal(1);
                    product.quantity = dr.GetInt32(2);

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


        /*Modelos Con Join*/
        public List<BuyedProductsJoinModel> allBuyed()
        {
            string query = "SELECT b.id, p.name, b.priceBuy, b.quantity, CONVERT(VARCHAR(10), b.register, 103)  FROM products p, buyedProducts b WHERE b.idProduct = p.id";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);
            List<BuyedProductsJoinModel> product = new List<BuyedProductsJoinModel>();

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {


                    product.Add(new BuyedProductsJoinModel
                    {

                        id = dr.GetInt32(0),
                        nameProduct = dr.GetString(1),
                        priceBuy = dr.GetDecimal(2),
                        quantity = dr.GetInt32(3),
                        register = dr.GetString(4)

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