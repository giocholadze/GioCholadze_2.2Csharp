using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using practice_3.Models;

namespace practice_3.Controllers
{
    public class CustomersController : Controller
    {
        private readonly string connectionString = "Data Source=DESKTOP-BS2HUTQ\\SQLEXPRESS;Initial Catalog=orders;Integrated Security=True;Trust Server Certificate=True";

        public void AddCustomer(Customers customer)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ShemkvetiID", customer.ShemkvetiID);
                cmd.Parameters.AddWithValue("@PersonaliID", customer.PersonaliID);
                cmd.Parameters.AddWithValue("@IuridiuliFizikuri", customer.IuridiuliFizikuri);
                cmd.Parameters.AddWithValue("@Gvari", customer.Gvari);
                cmd.Parameters.AddWithValue("@Saxeli", customer.Saxeli);
                cmd.Parameters.AddWithValue("@Qalaqi", customer.Qalaqi);
                cmd.Parameters.AddWithValue("@Regioni", customer.Regioni);
                cmd.Parameters.AddWithValue("@Raioni", customer.Raioni);
                cmd.Parameters.AddWithValue("@Sqesi", customer.Sqesi);
                cmd.Parameters.AddWithValue("@Misamarti", customer.Misamarti);
                cmd.Parameters.AddWithValue("@Mobiluri", customer.Mobiluri);
                cmd.Parameters.AddWithValue("@FirmisDasaxeleba", customer.FirmisDasaxeleba);
                cmd.Parameters.AddWithValue("@MobiluriDireqtoris", customer.MobiluriDireqtoris);
                cmd.Parameters.AddWithValue("@GvariDireqtoris", customer.GvariDireqtoris);
                cmd.Parameters.AddWithValue("@SabankoAngarishi", customer.SabankoAngarishi);
                cmd.Parameters.AddWithValue("@Email", customer.Email);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateCustomer(Customers customer)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ShemkvetiID", customer.ShemkvetiID);
                cmd.Parameters.AddWithValue("@PersonaliID", customer.PersonaliID);
                cmd.Parameters.AddWithValue("@IuridiuliFizikuri", customer.IuridiuliFizikuri);
                cmd.Parameters.AddWithValue("@Gvari", customer.Gvari);
                cmd.Parameters.AddWithValue("@Saxeli", customer.Saxeli);
                cmd.Parameters.AddWithValue("@Qalaqi", customer.Qalaqi);
                cmd.Parameters.AddWithValue("@Regioni", customer.Regioni);
                cmd.Parameters.AddWithValue("@Raioni", customer.Raioni);
                cmd.Parameters.AddWithValue("@Sqesi", customer.Sqesi);
                cmd.Parameters.AddWithValue("@Misamarti", customer.Misamarti);
                cmd.Parameters.AddWithValue("@Mobiluri", customer.Mobiluri);
                cmd.Parameters.AddWithValue("@FirmisDasaxeleba", customer.FirmisDasaxeleba);
                cmd.Parameters.AddWithValue("@MobiluriDireqtoris", customer.MobiluriDireqtoris);
                cmd.Parameters.AddWithValue("@GvariDireqtoris", customer.GvariDireqtoris);
                cmd.Parameters.AddWithValue("@SabankoAngarishi", customer.SabankoAngarishi);
                cmd.Parameters.AddWithValue("@Email", customer.Email);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public Customers GetCustomerData(string id)
        {
            Customers customer = new Customers();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Customers WHERE ShemkvetiID = @ShemkvetiID";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.AddWithValue("@ShemkvetiID", id);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    customer.ShemkvetiID = rdr["ShemkvetiID"].ToString();
                    customer.PersonaliID = rdr["PersonaliID"].ToString();
                    customer.IuridiuliFizikuri = rdr["IuridiuliFizikuri"].ToString();
                    customer.Gvari = rdr["Gvari"].ToString();
                    customer.Saxeli = rdr["Saxeli"].ToString();
                    customer.Qalaqi = rdr["Qalaqi"].ToString();
                    customer.Regioni = rdr["Regioni"].ToString();
                    customer.Raioni = rdr["Raioni"].ToString();
                    customer.Sqesi = rdr["Sqesi"].ToString();
                    customer.Misamarti = rdr["Misamarti"].ToString();
                    customer.Mobiluri = rdr["Mobiluri"].ToString();
                    customer.FirmisDasaxeleba = rdr["FirmisDasaxeleba"].ToString();
                    customer.MobiluriDireqtoris = rdr["MobiluriDireqtoris"].ToString();
                    customer.GvariDireqtoris = rdr["GvariDireqtoris"].ToString();
                    customer.SabankoAngarishi = rdr["SabankoAngarishi"].ToString();
                    customer.Email = rdr["Email"].ToString();
                }

                con.Close();
            }
            return customer;
        }

        public void DeleteCustomer(string id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ShemkvetiID", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
