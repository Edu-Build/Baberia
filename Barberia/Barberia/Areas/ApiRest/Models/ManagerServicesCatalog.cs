using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Barberia.Areas.ApiRest.Models
{
    public class ManagerServicesCatalog
    {
        private static string cadena = "Data Source=aed08db.database.windows.net; Initial Catalog=aed182e08; User ID=aed08user; Password=Aed08pas$;";

        public bool createService(ServicesCatalogModel service)
        {
            
            string query = "INSERT INTO serviceCatalog VALUES(@name,@type,@description,@price)";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();          
                cmd.Parameters.Add("@name", System.Data.SqlDbType.VarChar).Value = service.name;
                cmd.Parameters.Add("@type", System.Data.SqlDbType.VarChar).Value = service.type;
                cmd.Parameters.Add("@description", System.Data.SqlDbType.VarChar).Value = service.description;
                cmd.Parameters.Add("@price", System.Data.SqlDbType.Money).Value = service.price;
                


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


        public bool updateService(ServicesCatalogModel service)
        {


            string query = "UPDATE servicesCatalog SET   name = @name, type = @type, description_s = @descriptionS, price = @price WHERE id = @id";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = service.id;
                cmd.Parameters.Add("@name", System.Data.SqlDbType.VarChar).Value = service.name;
                cmd.Parameters.Add("@type", System.Data.SqlDbType.VarChar).Value = service.type;
                cmd.Parameters.Add("@descriptionS", System.Data.SqlDbType.VarChar).Value = service.description;
                cmd.Parameters.Add("@price", System.Data.SqlDbType.Money).Value = service.price;

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

        public ServicesCatalogModel returnService(int id)
        {
            string query = "SELECT * FROM servicesCatalog WHERE id = @id";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);
            ServicesCatalogModel service = new ServicesCatalogModel();

            try
            {
                conn.Open();
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                SqlDataReader dr = cmd.ExecuteReader();


                if (dr.Read())
                {

                    service.id = dr.GetInt32(0);
                    service.name = dr.GetString(1);
                    service.type = dr.GetString(2);
                    service.description = dr.GetString(3);
                    service.price = dr.GetDecimal(4);

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




        public List<ServicesCatalogModel> allService()
        {

            string query = "SELECT * FROM servicesCatalog";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);
            List<ServicesCatalogModel> service = new List<ServicesCatalogModel>();

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {


                    service.Add(new ServicesCatalogModel
                    {

                        id = dr.GetInt32(0),
                        name = dr.GetString(1),
                        type = dr.GetString(2),
                        description = dr.GetString(3),
                        price = dr.GetDecimal(4)
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


        public bool deleteService(int id)
        {

            string query = "DELETE FROM servicesCatalog WHERE id = @id";
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