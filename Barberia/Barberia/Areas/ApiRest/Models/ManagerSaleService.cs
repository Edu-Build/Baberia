using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Barberia.Areas.ApiRest.Models
{
    public class ManagerSaleService
    {
        private static string cadena = "Data Source=aed08db.database.windows.net; Initial Catalog=aed182e08; User ID=aed08user; Password=Aed08pas$;";

        public bool createSale(SaleServicesModel sale)
        {

            string query = "INSERT INTO saleServices VALUES(@idService,@idStore,@idEmploye,GETDATE(),@discount,@total)";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                cmd.Parameters.Add("@idService", System.Data.SqlDbType.Int).Value = sale.idService;
                cmd.Parameters.Add("@idStore", System.Data.SqlDbType.Int).Value = sale.idStore;
                cmd.Parameters.Add("@idEmploye", System.Data.SqlDbType.Int).Value = sale.idEmploye;
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

        public bool updateSaleService(SaleServicesModel sale)
        {
            string query = "UPDATE saleServices SET idReservation = @idReservation,idStore = @idStore, idEmploye = @idEmploye, discount = @discount, total = @total  WHERE id = @id";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = sale.id;
                cmd.Parameters.Add("@idService", System.Data.SqlDbType.Int).Value = sale.idService;
                cmd.Parameters.Add("@idStore", System.Data.SqlDbType.Int).Value = sale.idStore;
                cmd.Parameters.Add("@idEmploye", System.Data.SqlDbType.Int).Value = sale.idEmploye;
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

        public bool deleteSaleService(int id)
        {
            string query = "DELETE FROM saleServices WHERE id = @id";
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

        public SaleServicesModel returnSaleService(int id)
        {
            string query = "SELECT idService, idStore, idEmploy, discount, total FROM saleServices WHERE id = @id";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);
            SaleServicesModel sale = new SaleServicesModel();


            try
            {
                conn.Open();
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                SqlDataReader dr = cmd.ExecuteReader();


                if (dr.Read())
                {
                    sale.idService = dr.GetInt32(0);
                    sale.idStore = dr.GetInt32(1);
                    sale.idEmploye = dr.GetInt32(2);
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
        public List<SaleServicesJoinModel> allSaleServices()
        {
            string query = "SELECT ss.id, s.Name, t.Name,  e.name +' '+ e.firts_name, CONVERT(VARCHAR(10), ss.dataSale, 103), ss.discount, ss.total FROM saleServices ss, servicesCatalog s, storeCatalog t, employees e WHERE ss.idService = s.id AND ss.idStore = t.id AND ss.idEmploy = e.id";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);
            List<SaleServicesJoinModel> saleService = new List<SaleServicesJoinModel>();

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {


                    saleService.Add(new SaleServicesJoinModel
                    {

                        id = dr.GetInt32(0),
                        nameService = dr.GetString(1),
                        nameStore = dr.GetString(2),
                        nameEmploye = dr.GetString(3),
                        dateRegister = dr.GetString(4),
                        discount = dr.GetDouble(5),
                        total = dr.GetDecimal(6)
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
            return saleService;
        }
    }
}