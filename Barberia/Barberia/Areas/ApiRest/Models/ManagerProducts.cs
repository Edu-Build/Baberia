using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Barberia.Areas.ApiRest.Models
{
    public class ManagerProducts
    {
        private static string cadena = "Data Source=aed08db.database.windows.net; Initial Catalog=aed182e08; User ID=aed08user; Password=Aed08pas$;";

        public bool createProducto(ProductsModel product)
        {

            string query = "INSERT INTO products VALUES(@idBrand,@idType,@name,@description,@salePrice,@quantity) ";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                cmd.Parameters.Add("@idBrand", System.Data.SqlDbType.Char).Value = product.idBrand;
                cmd.Parameters.Add("@idType", System.Data.SqlDbType.Char).Value = product.idType;
                cmd.Parameters.Add("@name", System.Data.SqlDbType.VarChar).Value = product.name;
                cmd.Parameters.Add("@description", System.Data.SqlDbType.VarChar).Value = product.description;
                cmd.Parameters.Add("@salePrice", System.Data.SqlDbType.Money).Value = product.salePrice;
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

        public bool updateProduct(ProductsModel product)
        {
            string query = "UPDATE products SET idBrand = @idBrand, idType = @idType, name = @name, descriptions = @description, salePrice = @salePrice, quantity = @quantity  WHERE id = @id";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = product.id;
                cmd.Parameters.Add("@idBrand", System.Data.SqlDbType.Char).Value = product.idBrand;
                cmd.Parameters.Add("@idType", System.Data.SqlDbType.Char).Value = product.idType;
                cmd.Parameters.Add("@name", System.Data.SqlDbType.VarChar).Value = product.name;
                cmd.Parameters.Add("@description", System.Data.SqlDbType.VarChar).Value = product.description;
                cmd.Parameters.Add("@salePrice", System.Data.SqlDbType.Money).Value = product.salePrice;
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
            string query = "DELETE FROM products WHERE id = @id";
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

        public ProductsModel returnProduct(int id)
        {
            string query = "SELECT idBrand, idType, name, descriptions, salePrice, quantity FROM products WHERE id = @id";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);
            ProductsModel product = new ProductsModel();


            try
            {
                conn.Open();
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                SqlDataReader dr = cmd.ExecuteReader();


                if (dr.Read())
                {
                    product.idBrand = dr.GetString(0);
                    product.idType = dr.GetString(1);
                    product.name = dr.GetString(2);
                    product.description = dr.GetString(3);
                    product.salePrice = dr.GetDecimal(4);
                    product.quantity = dr.GetInt32(5);

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
        public List<ProductsJoinModel> allProduct()
        {
            string query = "SELECT p.id, p.name, b.name, t.name, p.descriptions, p.salePrice, p.quantity FROM products p, typeProduct t, brandProducts b WHERE p.idBrand = b.id AND p.idType = t.id ";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);
            List<ProductsJoinModel> product = new List<ProductsJoinModel>();

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {


                    product.Add(new ProductsJoinModel
                    {

                        id = dr.GetInt32(0),
                        nameProduct = dr.GetString(1),
                        nameBrand = dr.GetString(2),
                        nameType = dr.GetString(3),
                        description = dr.GetString(4),
                        salePrice = dr.GetDecimal(5),
                        quantity = dr.GetInt32(6),
                       
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


        /*Alta Producto*/
        public bool updateProductHigh(ProductsActionModel product)
        {
            string query = "UPDATE products SET  quantity = (quantity + @quantity) WHERE id = @id";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = product.id;
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


        /*Baja Producto*/
        public bool updateProductDown(ProductsActionModel product)
        {
            string query = "UPDATE products SET  quantity = (quantity - @quantity) WHERE id = @id";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = product.id;
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


        /*Retorno de Cantidad*/
        public ProductsModel returnQuantity(int id)
        {
            string query = "SELECT quantity FROM products WHERE id = @id";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);
            ProductsModel product = new ProductsModel();


            try
            {
                conn.Open();
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                SqlDataReader dr = cmd.ExecuteReader();


                if (dr.Read())
                {
                   
                    product.quantity = dr.GetInt32(0);

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