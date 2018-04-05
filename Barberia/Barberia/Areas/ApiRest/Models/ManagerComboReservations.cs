using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Barberia.Areas.ApiRest.Models
{
    public class ManagerComboReservations
    {
        private static string cadena = "Data Source=aed08db.database.windows.net; Initial Catalog=aed182e08; User ID=aed08user; Password=Aed08pas$;";




        public ComboReservationModel retunrReservationSale(int id)
        {

            string query = "SELECT r.id, r.name + ' ' + r.flName, s.id, s.name, s.price FROM reservations r, servicesCatalog s WHERE r.idService = s.id AND r.id = @id";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);
            ComboReservationModel reservation = new ComboReservationModel();

            try
            {
                conn.Open();
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                SqlDataReader dr = cmd.ExecuteReader();


                if (dr.Read())
                {
                    reservation.id = dr.GetInt32(0);
                    reservation.name = dr.GetString(1);
                    reservation.idService = dr.GetInt32(2);
                    reservation.nameService= dr.GetString(3);
                    reservation.price = dr.GetDecimal(4);
                }


            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return reservation;

        }



        public List<ComboReservationModel> ComboService()
        {

            string query = "SELECT id, name + ' ' + flName FROM reservations";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);
            List<ComboReservationModel> reservation = new List<ComboReservationModel>();

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {


                    reservation.Add(new ComboReservationModel
                    {

                        id = dr.GetInt32(0),
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
            return reservation;

        }

    }
}