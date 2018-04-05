using Barberia.Areas.ApiRest.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Barberia.Areas.ApiRest.Models
{
    public class ManagerSaleServiceReservation
    {
        private static string cadena = "Data Source=aed08db.database.windows.net; Initial Catalog=aed182e08; User ID=aed08user; Password=Aed08pas$;";

        public bool createSaleReservation(SaleServiceReservationModel sale)
        {

            string query = "INSERT INTO saleServicesReservation VALUES(@idReservation,@idEmploye,GETDATE(),@discount,@total)";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                cmd.Parameters.Add("@idReservation", System.Data.SqlDbType.Int).Value = sale.idReservation;
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

        public bool updateSaleReservations(SaleServiceReservationModel sale)
        {
            string query = "UPDATE saleServicesReservation SET idReservation = @idReservation, idEmploye = @idEmploye, discount = @discount, total = @total  WHERE id = @id";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = sale.id;
                cmd.Parameters.Add("@idReservation", System.Data.SqlDbType.Int).Value = sale.idReservation;
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

        public bool deleteSaleReservations(int id)
        {
            string query = "DELETE FROM saleServicesReservation WHERE id = @id";
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

        public SaleServiceReservationModel returnSaleReservation(int id)
        {
            string query = "SELECT idReservation,  idEmploy, discount, total FROM saleServicesReservation WHERE id = @id";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);
            SaleServiceReservationModel sale = new SaleServiceReservationModel();


            try
            {
                conn.Open();
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                SqlDataReader dr = cmd.ExecuteReader();


                if (dr.Read())
                {
                    sale.idReservation = dr.GetInt32(0);
                    sale.idEmploye = dr.GetInt32(1);
                    sale.discount = dr.GetDouble(2);
                    sale.total = dr.GetDecimal(3);
                  
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
        public List<SaleServiceReserJoinModel> allSaleReservation()
        {
            string query = "SELECT sr.id, r.name +' ' + r.flName, s.name, t.name, e.name +' '+ e.firts_name, CONVERT(VARCHAR(10), sr.dataSale, 103), sr.discount, sr.total FROM saleServicesReservation sr,reservations r, servicesCatalog s, storeCatalog t, employees e WHERE sr.idReservation = r.id AND r.idService = s.id AND r.idStore = t.id AND sr.idEmploy = e.id  ";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);
            List<SaleServiceReserJoinModel> saleReservation = new List<SaleServiceReserJoinModel>();

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {


                    saleReservation.Add(new SaleServiceReserJoinModel
                    {

                       id = dr.GetInt32(0),
                       nameReservation = dr.GetString(1),
                       nameService = dr.GetString(2),
                       nameStore = dr.GetString(3),
                       nameEmploye = dr.GetString(4),
                       dateRegister = dr.GetString(5),
                       discount = dr.GetDouble(6),
                       total = dr.GetDecimal(7)
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
            return saleReservation;
        }

    }
}