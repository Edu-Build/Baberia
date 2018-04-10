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

            string query = "INSERT INTO reservations VALUES  (@idService,@idStore,@email,@name,@flName,GETDATE(),@reservation,DEFAULT)";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                cmd.Parameters.Add("@idService", System.Data.SqlDbType.Int).Value = reservation.idService;
                cmd.Parameters.Add("@idStore", System.Data.SqlDbType.Int).Value = reservation.idStore;
                cmd.Parameters.Add("@email", System.Data.SqlDbType.VarChar).Value = reservation.email;
                cmd.Parameters.Add("@name", System.Data.SqlDbType.VarChar).Value = reservation.name;
                cmd.Parameters.Add("@flName", System.Data.SqlDbType.VarChar).Value = reservation.flName;
                cmd.Parameters.Add("@reservation", System.Data.SqlDbType.VarChar).Value = reservation.reservation;
               
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
            string query = "UPDATE reservations SET idService = @idService, email = @email, name = @name, flName = @flName, reservation = @reservation, process = @process WHERE id = @id";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = reservation.id;
                cmd.Parameters.Add("@idService", System.Data.SqlDbType.Int).Value = reservation.idService;
                cmd.Parameters.Add("@email", System.Data.SqlDbType.VarChar).Value = reservation.email;
                cmd.Parameters.Add("@name", System.Data.SqlDbType.VarChar).Value = reservation.name;
                cmd.Parameters.Add("@flName", System.Data.SqlDbType.VarChar).Value = reservation.flName;
                cmd.Parameters.Add("@reservation", System.Data.SqlDbType.VarChar).Value = reservation.reservation;
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

        public bool updateReservationProcess(int id)
        {
            string query = "UPDATE reservations SET process = 'EXITOSA..' WHERE id = @id";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                

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

        public ReservationsModel returnReservation(int id)
        {
            string query = "SELECT idService, email, name, flName, reservation, process FROM reservations WHERE id = @id";
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(query, conn);
            ReservationsModel reservation = new ReservationsModel();


            try
            {
                conn.Open();
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                SqlDataReader dr = cmd.ExecuteReader();


                if (dr.Read())
                {
                    reservation.idService = dr.GetInt32(0);
                    reservation.email = dr.GetString(1);
                    reservation.name = dr.GetString(2);
                    reservation.flName = dr.GetString(3);
                    reservation.reservation = dr.GetString(4);
                    reservation.process = dr.GetString(5);
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


        /*Modelos Con Join*/
        public List<ReservationsJoinModel> allReservations()
        {
            string query = "SELECT R.id, S.name, T.name, R.email, R.name, R.flName, CONVERT(VARCHAR(10), R.dateReservation, 103), R.reservation, R.process FROM reservations R, serviceSCatalog S, storeCatalog T  WHERE R.idService = S.id  AND R.idStore = T.id";
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
                        nameService = dr.GetString(1),
                        nameStore = dr.GetString(2),
                        email = dr.GetString(3),
                        name = dr.GetString(4),
                        nameFL = dr.GetString(5),
                        dateReservation= dr.GetString(6),
                        reservation = dr.GetString(7),
                        process = dr.GetString(8)


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