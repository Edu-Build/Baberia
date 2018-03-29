using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Barberia.Areas.ApiRest.Models
{
    public class ManagerReservations
    {
        private static string cadena = "Data Source=aed08db.database.windows.net; Initial Catalog=aed182e08; User ID=aed08user; Password=Aed08pas$;";

        public bool createReservations(ReservationsModel reservation)
        {

            string query = "INSERT INTO reservations VALUES(@id,@idCustomer,@idService,@idStore,@createReservation,@dataReservation,@process)";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = reservation.id;
                cmd.Parameters.Add("@idCustomer", System.Data.SqlDbType.Int).Value = reservation.idCustomer;
                cmd.Parameters.Add("@idService", System.Data.SqlDbType.Int).Value = reservation.idService;
                cmd.Parameters.Add("@idStore", System.Data.SqlDbType.Int).Value = reservation.idStore;
                cmd.Parameters.Add("@createReservation", System.Data.SqlDbType.Date).Value = reservation.createReservation;
                cmd.Parameters.Add("@dataReservation", System.Data.SqlDbType.Date).Value = reservation.dataReservation;
                cmd.Parameters.Add("@process", System.Data.SqlDbType.VarChar).Value = reservation.process;

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

        public bool updateReservations(ReservationsModel reservation)
        {
            string query = "UPDATE reservation SET dateTime_reservation = @dataReservation, process = @process id = @id";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = reservation.id;
                cmd.Parameters.Add("@createReservation", System.Data.SqlDbType.Date).Value = reservation.createReservation;
                cmd.Parameters.Add("@dataReservation", System.Data.SqlDbType.Date).Value = reservation.dataReservation;
                cmd.Parameters.Add("@process", System.Data.SqlDbType.VarChar).Value = reservation.process;

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

        public ReservationsJoinModel returnReservation(int id)
        {
            string query = "SELECT r.id,  c.name +' '+ c.last_name +' '+ c.firts_name, s.name, t.name, CONVERT(VARCHAR, r.dateTime_day),CONVERT(VARCHAR,r.dateTime_reservation) , r.process FROM reservations r, customers c, storeCatalog t, servicesCatalog s WHERE r.idCustomer = c.id  AND   r.idService = s.id and   r.idStore = t.id AND r.id = @id";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);
            ReservationsJoinModel reservation = new ReservationsJoinModel();
        

            try
            {
                conn.Open();
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                SqlDataReader dr = cmd.ExecuteReader();
                

                if (dr.Read())
                {

                    reservation.id = dr.GetInt32(0);
                    reservation.name = dr.GetString(1);
                    reservation.service = dr.GetString(2);
                    reservation.store = dr.GetString(3);
                    reservation.createReservation = dr.GetString(4);
                    reservation.dataReservation = dr.GetString(5);
                    reservation.process = dr.GetString(6);
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


        public List<ReservationsJoinModel> allReservations()
        {
            string query = "SELECT r.id,  c.name +' '+ c.last_name +' '+ c.firts_name, s.name, t.name, CONVERT(VARCHAR,r.dateTime_day), CONVERT(VARCHAR,r.dateTime_reservation),r.process FROM reservations r, customers c, storeCatalog t, servicesCatalog s WHERE r.idCustomer = c.id  AND   r.idService = s.id and   r.idStore = t.id ";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);
            List<ReservationsJoinModel> reservation = new List<ReservationsJoinModel>();

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {


                    reservation.Add(new ReservationsJoinModel
                    {

                        id = dr.GetInt32(0),
                        name = dr.GetString(1),
                        service = dr.GetString(2),
                        store = dr.GetString(3),
                        createReservation = dr.GetString(4),
                        dataReservation = dr.GetString(5),
                        process = dr.GetString(6)


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


        public bool deleteReservations(int id)
        {
            string query = "DELETE FROM reservations WHERE id = @id";
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