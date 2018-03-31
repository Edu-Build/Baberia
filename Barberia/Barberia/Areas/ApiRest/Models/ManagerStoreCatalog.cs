using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Barberia.Areas.ApiRest.Models
{
    public class ManagerStoreCatalog
    {
        private static string cadena = "Data Source=aed08db.database.windows.net; Initial Catalog=aed182e08; User ID=aed08user; Password=Aed08pas$;";

        public  bool createStore(StoreCatalogModel store) {

            string query = "INSERT INTO storeCatalog VALUES(@name,@state,@town,@address,@phone)";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                cmd.Parameters.Add("@name", System.Data.SqlDbType.VarChar).Value = store.name;
                cmd.Parameters.Add("@state", System.Data.SqlDbType.VarChar).Value = store.state;
                cmd.Parameters.Add("@town", System.Data.SqlDbType.VarChar).Value = store.town;
                cmd.Parameters.Add("@address", System.Data.SqlDbType.VarChar).Value = store.address;
                cmd.Parameters.Add("@phone", System.Data.SqlDbType.VarChar).Value = store.phone;
                

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


        public  bool updateStore(StoreCatalogModel store) {


            string query = "UPDATE storeCatalog SET  name = @name, state = @state, town = @town, addressSt = @address, phone = @phone WHERE id = @id";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = store.id;
                cmd.Parameters.Add("@name", System.Data.SqlDbType.VarChar).Value = store.name;
                cmd.Parameters.Add("@state", System.Data.SqlDbType.VarChar).Value = store.state;
                cmd.Parameters.Add("@town", System.Data.SqlDbType.VarChar).Value = store.town;
                cmd.Parameters.Add("@address", System.Data.SqlDbType.VarChar).Value = store.address;
                cmd.Parameters.Add("@phone", System.Data.SqlDbType.VarChar).Value = store.phone;

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

        public  StoreCatalogModel returnStore(int id) {
            string query = "SELECT * FROM storeCatalog WHERE id = @id";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);
            StoreCatalogModel store = new StoreCatalogModel();

            try
            {
                conn.Open();
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                SqlDataReader dr = cmd.ExecuteReader();


                if (dr.Read())
                {

                    store.id = dr.GetInt32(0);
                    store.name = dr.GetString(1);
                    store.state = dr.GetString(2);
                    store.town = dr.GetString(3);
                    store.address = dr.GetString(4);
                    store.phone = dr.GetString(5);
                    
                }


            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return store;
        }


        public  List<StoreCatalogModel> allStore() {

            string query = "SELECT * FROM storeCatalog";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);
            List<StoreCatalogModel> store = new List<StoreCatalogModel>();

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {


                    store.Add(new StoreCatalogModel
                    {

                        id = dr.GetInt32(0),
                        name = dr.GetString(1),
                        state = dr.GetString(2),
                        town = dr.GetString(3),
                        address = dr.GetString(4),
                        phone = dr.GetString(5),

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
            return store;

        }


        public  bool deleteStore(int id) {

            string query = "DELETE FROM storeCatalog WHERE id = @id";
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