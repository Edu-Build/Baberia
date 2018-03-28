using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Barberia.Areas.ApiRest.Models
{
    public class ManagerCustomers
    {

        private static string cadena = "Data Source=aed08db.database.windows.net; Initial Catalog=aed182e08; User ID=aed08user; Password=Aed08pas$;";

        public bool createCustomer(CustomersModel customer)
        {
            var resultado = new respuesta();
            string query = "INSERT INTO customers VALUES(@id,@email,@name,@firstName,@lastName,@cellPhone,@homePhone)";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = customer.id;
                cmd.Parameters.Add("@email", System.Data.SqlDbType.VarChar).Value = customer.email;
                cmd.Parameters.Add("@name", System.Data.SqlDbType.VarChar).Value = customer.name;
                cmd.Parameters.Add("@firstName", System.Data.SqlDbType.VarChar).Value = customer.firstName;
                cmd.Parameters.Add("@lastName", System.Data.SqlDbType.VarChar).Value = customer.lastName;
                cmd.Parameters.Add("@cellPhone", System.Data.SqlDbType.VarChar).Value = customer.cellPhone;
                cmd.Parameters.Add("@homePhone", System.Data.SqlDbType.VarChar).Value = customer.homePhone;

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

        public bool updateCustomer(CustomersModel customer)
        {
            string query = "UPDATE customers SET  email = @email, name = @name, firts_name = @firstName, last_name = @lastName, cell_phone = @cellPhone, home_phone = @homePhone WHERE id = @id";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = customer.id;
                cmd.Parameters.Add("@email", System.Data.SqlDbType.VarChar).Value = customer.email;
                cmd.Parameters.Add("@name", System.Data.SqlDbType.VarChar).Value = customer.name;
                cmd.Parameters.Add("@firstName", System.Data.SqlDbType.VarChar).Value = customer.firstName;
                cmd.Parameters.Add("@lastName", System.Data.SqlDbType.VarChar).Value = customer.lastName;
                cmd.Parameters.Add("@cellPhone", System.Data.SqlDbType.VarChar).Value = customer.cellPhone;
                cmd.Parameters.Add("@homePhone", System.Data.SqlDbType.VarChar).Value = customer.homePhone;

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

        public CustomersModel returnCustomer(int id)
        {
            string query = "SELECT * FROM customers WHERE id = @id";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);
            CustomersModel customer = new CustomersModel();

            try
            {
                conn.Open();
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                SqlDataReader dr = cmd.ExecuteReader();


                if (dr.Read())
                {

                    customer.id = dr.GetInt32(0);
                    customer.email = dr.GetString(1);
                    customer.name = dr.GetString(2);
                    customer.firstName = dr.GetString(3);
                    customer.lastName = dr.GetString(4);
                    customer.cellPhone = dr.GetString(5);
                    customer.homePhone = dr.GetString(6);
                }


            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return customer;
        }


        public List<CustomersModel> allCustomers()
        {
            string query = "SELECT * FROM customers";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);
            List<CustomersModel> customer = new List<CustomersModel>();

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {


                    customer.Add(new CustomersModel
                    {

                        id = dr.GetInt32(0),
                        email = dr.GetString(1),
                        name = dr.GetString(2),
                        firstName = dr.GetString(3),
                        lastName = dr.GetString(4),
                        cellPhone = dr.GetString(5),
                        homePhone = dr.GetString(6)

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
            return customer;
        }


        public bool deleteCustomer(int id)
        {
            string query = "DELETE FROM customers WHERE id = @id";
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


        public class respuesta
        {
            public bool ok { get; set; }
            public string mensaje { get; set; }
        }
    }
}