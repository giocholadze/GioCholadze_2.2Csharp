using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using practice_3.Models;
using Practice_3.Models;

namespace practice_3.Controllers
{
    public class OrdersController : Controller
    {
        private readonly string connectionString = "Data Source=DESKTOP-BS2HUTQ\\SQLEXPRESS;Initial Catalog=orders;Integrated Security=True;Trust Server Certificate=True";

        public void AddOrder(Orders order)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddOrder", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@XelshekrulebaID", order.XelshekrulebaID);
                cmd.Parameters.AddWithValue("@PersonaliID", order.PersonaliID);
                cmd.Parameters.AddWithValue("@ShemkvetiID", order.ShemkvetiID);
                cmd.Parameters.AddWithValue("@Gadasaxdeli_l", order.Gadasaxdeli_l);
                cmd.Parameters.AddWithValue("@Gadasaxdeli_d", order.Gadasaxdeli_d);
                cmd.Parameters.AddWithValue("@Gadaxdili_l", order.Gadaxdili_l);
                cmd.Parameters.AddWithValue("@Gadaxdili_d", order.Gadaxdili_d);
                cmd.Parameters.AddWithValue("@Vali_l", order.Vali_l);
                cmd.Parameters.AddWithValue("@Vali_d", order.Vali_d);
                cmd.Parameters.AddWithValue("@Kursi", order.Kursi);
                cmd.Parameters.AddWithValue("@Tarigi_dawyebis", order.Tarigi_dawyebis);
                cmd.Parameters.AddWithValue("@Tarigi_shesrulebis", order.Tarigi_shesrulebis);
                cmd.Parameters.AddWithValue("@Tarigi_damtavrebis", order.Tarigi_damtavrebis);
                cmd.Parameters.AddWithValue("@Shesruleba", order.Shesruleba);
                cmd.Parameters.AddWithValue("@Visi_mizezit", order.Visi_mizezit);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateOrder(Orders order)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateOrder", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@XelshekrulebaID", order.XelshekrulebaID);
                cmd.Parameters.AddWithValue("@PersonaliID", order.PersonaliID);
                cmd.Parameters.AddWithValue("@ShemkvetiID", order.ShemkvetiID);
                cmd.Parameters.AddWithValue("@Gadasaxdeli_l", order.Gadasaxdeli_l);
                cmd.Parameters.AddWithValue("@Gadasaxdeli_d", order.Gadasaxdeli_d);
                cmd.Parameters.AddWithValue("@Gadaxdili_l", order.Gadaxdili_l);
                cmd.Parameters.AddWithValue("@Gadaxdili_d", order.Gadaxdili_d);
                cmd.Parameters.AddWithValue("@Vali_l", order.Vali_l);
                cmd.Parameters.AddWithValue("@Vali_d", order.Vali_d);
                cmd.Parameters.AddWithValue("@Kursi", order.Kursi);
                cmd.Parameters.AddWithValue("@Tarigi_dawyebis", order.Tarigi_dawyebis);
                cmd.Parameters.AddWithValue("@Tarigi_shesrulebis", order.Tarigi_shesrulebis);
                cmd.Parameters.AddWithValue("@Tarigi_damtavrebis", order.Tarigi_damtavrebis);
                cmd.Parameters.AddWithValue("@Shesruleba", order.Shesruleba);
                cmd.Parameters.AddWithValue("@Visi_mizezit", order.Visi_mizezit);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public Orders GetOrderData(string id)
        {
            Orders order = new Orders();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Orders WHERE XelshekrulebaID = @XelshekrulebaID";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.AddWithValue("@XelshekrulebaID", id);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    order.XelshekrulebaID = rdr["XelshekrulebaID"].ToString();
                    order.PersonaliID = rdr["PersonaliID"].ToString();
                    order.ShemkvetiID = rdr["ShemkvetiID"].ToString();
                    order.Gadasaxdeli_l = rdr["Gadasaxdeli_l"].ToString();
                    order.Gadasaxdeli_d = rdr["Gadasaxdeli_d"].ToString();
                    order.Gadaxdili_l = rdr["Gadaxdili_l"].ToString();
                    order.Gadaxdili_d = rdr["Gadaxdili_d"].ToString();
                    order.Vali_l = rdr["Vali_l"].ToString();
                    order.Vali_d = rdr["Vali_d"].ToString();
                    order.Kursi = rdr["Kursi"].ToString();
                    order.Tarigi_dawyebis = rdr["Tarigi_dawyebis"].ToString();
                    order.Tarigi_shesrulebis = rdr["Tarigi_shesrulebis"].ToString();
                    order.Tarigi_damtavrebis = rdr["Tarigi_damtavrebis"].ToString();
                    order.Shesruleba = rdr["Shesruleba"].ToString();
                    order.Visi_mizezit = rdr["Visi_mizezit"].ToString();
                }
                con.Close();
            }
            return order;
        }

        public void DeleteOrder(string id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteOrder", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@XelshekrulebaID", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
    