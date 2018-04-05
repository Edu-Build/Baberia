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
        public List<ComboReservationModel> ComboService()
        {

            string query = "SELECT r.id, r.name + ' ' + r.flName, s.id, s.name, s.price FROM reservations r, servicesCatalog s WHERE r.idService = s.id";
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
                        idService = dr.GetInt32(2),
                        nameService = dr.GetString(3),
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
            return reservation;

        }
    }
}