using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Barberia.Areas.ApiRest.Models
{
    public class ManagerSaleProducts
    {
        private static string cadena = "Data Source=aed08db.database.windows.net; Initial Catalog=aed182e08; User ID=aed08user; Password=Aed08pas$;";

        public bool createRegisterSale(SaleProductModel sale)
        {
            
            string query = "INSERT INTO saleProduct VALUES(@idProduct, @idStore, @quantity, @discount, @total, GETDATE())";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                cmd.Parameters.Add("@idProduct", System.Data.SqlDbType.Int).Value = sale.idProduct;
                cmd.Parameters.Add("@idStore", System.Data.SqlDbType.Money).Value = sale.idStore;
                cmd.Parameters.Add("@quantity", System.Data.SqlDbType.Int).Value = sale.quantity;
                cmd.Parameters.Add("@discount", System.Data.SqlDbType.Float).Value = sale.discount;
                cmd.Parameters.Add("@total", System.Data.SqlDbType.Money).Value = sale.total;

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

        public bool updateRegisterSale(SaleProductModel sale)
        {
            string query = "UPDATE saleProduct SET idProduct = @idProduct, idStore = @idStore, quantity = @quantity, total = @total WHERE id = @id";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = sale.id;
                cmd.Parameters.Add("@idProduct", System.Data.SqlDbType.Int).Value = sale.idProduct;
                cmd.Parameters.Add("@idStore", System.Data.SqlDbType.Money).Value = sale.idStore;
                cmd.Parameters.Add("@quantity", System.Data.SqlDbType.Int).Value = sale.quantity;
                cmd.Parameters.Add("@discount", System.Data.SqlDbType.Float).Value = sale.discount;
                cmd.Parameters.Add("@total", System.Data.SqlDbType.Money).Value = sale.total;

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

        public bool deleteRegisterSale(int id)
        {
            string query = "DELETE FROM saleProduct WHERE id = @id";
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

        public SaleProductModel returnRegisterSale(int id)
        {
            string query = "SELECT idProduct, idStore, quantity, discount, total FROM saleProduct WHERE id = @id";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);
            SaleProductModel sale = new SaleProductModel();


            try
            {
                conn.Open();
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                SqlDataReader dr = cmd.ExecuteReader();


                if (dr.Read())
                {
                    sale.idProduct = dr.GetInt32(0);
                    sale.idStore = dr.GetInt32(1);
                    sale.quantity = dr.GetInt32(2);
                    sale.discount = dr.GetDouble(3);
                    sale.total = dr.GetDecimal(4);
                }


            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return sale;
        }


        /*Modelos Con Join*/
        public List<SaleProductsJoinModel> allRegisterSale()
        {
            string query = "SELECT s.id, p.name, t.name, s.quantity, s.discount, s.total,  CONVERT(VARCHAR(10), s.registerSale, 103) FROM saleProduct s, storeCatalog t, products p WHERE s.idProduct = p.id AND s.idStore = t.id";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);
            List<SaleProductsJoinModel> sale = new List<SaleProductsJoinModel>();

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {


                    sale.Add(new SaleProductsJoinModel
                    {

                        id = dr.GetInt32(0),
                        nameProduct = dr.GetString(1),
                        nameStore = dr.GetString(2),
                        quantity = dr.GetInt32(3),
                        discount = dr.GetDouble(4),
                        total = dr.GetDecimal(5),
                        registerSale = dr.GetString(6)

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
            return sale;
        }
    }
}
