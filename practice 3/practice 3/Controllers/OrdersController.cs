using System;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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

                cmd.Parameters.AddWithValue("@XelshekrulebaID", order.xelshekrulebaID );
                cmd.Parameters.AddWithValue("@PersonaliID", order.personaliID );
                cmd.Parameters.AddWithValue("@ShemkvetiID", order.shemkvetiID );
                cmd.Parameters.AddWithValue("@Gadasaxdeli_l", order.gadasaxdeli_l );
                cmd.Parameters.AddWithValue("@Gadasaxdeli_d", order.gadasaxdeli_d );
                cmd.Parameters.AddWithValue("@Gadaxdili_l", order.gadaxdili_l );
                cmd.Parameters.AddWithValue("@Gadaxdili_d", order.gadaxdili_d );
                cmd.Parameters.AddWithValue("@Vali_l", order.vali_l );
                cmd.Parameters.AddWithValue("@Vali_d", order.vali_d );
                cmd.Parameters.AddWithValue("@Kursi", order.kursi );
                cmd.Parameters.AddWithValue("@Tarigi_dawyebis", order.tarigi_dawyebis );
                cmd.Parameters.AddWithValue("@Tarigi_shesrulebis", order.tarigi_shesrulebis );
                cmd.Parameters.AddWithValue("@Tarigi_damtavrebis", order.tarigi_damtavrebis );
                cmd.Parameters.AddWithValue("@Shesruleba", order.shesruleba );
                cmd.Parameters.AddWithValue("@Visi_mizezit", order.visi_mizezit);

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

                cmd.Parameters.AddWithValue("@XelshekrulebaID", order.xelshekrulebaID );
                cmd.Parameters.AddWithValue("@PersonaliID", order.personaliID );
                cmd.Parameters.AddWithValue("@ShemkvetiID", order.shemkvetiID );
                cmd.Parameters.AddWithValue("@Gadasaxdeli_l", order.gadasaxdeli_l );
                cmd.Parameters.AddWithValue("@Gadasaxdeli_d", order.gadasaxdeli_d );
                cmd.Parameters.AddWithValue("@Gadaxdili_l", order.gadaxdili_l );
                cmd.Parameters.AddWithValue("@Gadaxdili_d", order.gadaxdili_d );
                cmd.Parameters.AddWithValue("@Vali_l", order.vali_l );
                cmd.Parameters.AddWithValue("@Vali_d", order.vali_d );
                cmd.Parameters.AddWithValue("@Kursi", order.kursi );
                cmd.Parameters.AddWithValue("@Tarigi_dawyebis", order.tarigi_dawyebis );
                cmd.Parameters.AddWithValue("@Tarigi_shesrulebis", order.tarigi_shesrulebis );
                cmd.Parameters.AddWithValue("@Tarigi_damtavrebis", order.tarigi_damtavrebis );
                cmd.Parameters.AddWithValue("@Shesruleba", order.shesruleba );
                cmd.Parameters.AddWithValue("@Visi_mizezit", order.visi_mizezit);

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
                    order.xelshekrulebaID = rdr["XelshekrulebaID"].ToString();
                    order.personaliID = rdr["PersonaliID"].ToString();
                    order.shemkvetiID = rdr["ShemkvetiID"].ToString();
                    order.gadasaxdeli_l = rdr["Gadasaxdeli_l"].ToString();
                    order.gadasaxdeli_d = rdr["Gadasaxdeli_d"].ToString();
                    order.gadaxdili_l = rdr["Gadaxdili_l"].ToString();
                    order.gadaxdili_d = rdr["Gadaxdili_d"].ToString();
                    order.vali_l = rdr["Vali_l"].ToString();
                    order.vali_d = rdr["Vali_d"].ToString();
                    order.kursi = rdr["Kursi"].ToString();
                    order.tarigi_dawyebis = rdr["Tarigi_dawyebis"].ToString();
                    order.tarigi_shesrulebis = rdr["Tarigi_shesrulebis"].ToString();
                    order.tarigi_damtavrebis = rdr["Tarigi_damtavrebis"].ToString();
                    order.shesruleba = rdr["Shesruleba"].ToString();
                    order.visi_mizezit = rdr["Visi_mizezit"].ToString();
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
    