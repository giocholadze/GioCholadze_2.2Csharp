using System;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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

                cmd.Parameters.AddWithValue("@ShemkvetiID", customer.shemkvetiID);
                cmd.Parameters.AddWithValue("@PersonaliID", customer.personaliID);
                cmd.Parameters.AddWithValue("@IuridiuliFizikuri", customer.iuridiuli_fizikuri);
                cmd.Parameters.AddWithValue("@Gvari", customer.gvari);
                cmd.Parameters.AddWithValue("@Saxeli", customer.saxeli);
                cmd.Parameters.AddWithValue("@Qalaqi", customer.qalaqi);
                cmd.Parameters.AddWithValue("@Regioni", customer.regioni);
                cmd.Parameters.AddWithValue("@Raioni", customer.raioni);
                cmd.Parameters.AddWithValue("@Sqesi", customer.sqesi);
                cmd.Parameters.AddWithValue("@Misamarti", customer.misamarti);
                cmd.Parameters.AddWithValue("@Mobiluri", customer.mobiluri);
                cmd.Parameters.AddWithValue("@FirmisDasaxeleba", customer.firmis_dasaxeleba);
                cmd.Parameters.AddWithValue("@MobiluriDireqtoris", customer.mobiluri_direqtoris);
                cmd.Parameters.AddWithValue("@GvariDireqtoris", customer.gvari_direqtoris);
                cmd.Parameters.AddWithValue("@SabankoAngarishi", customer.sabanko_angarishi);
                cmd.Parameters.AddWithValue("@Email", customer.email);

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

                cmd.Parameters.AddWithValue("@ShemkvetiID", customer.shemkvetiID);
                cmd.Parameters.AddWithValue("@PersonaliID", customer.personaliID);
                cmd.Parameters.AddWithValue("@IuridiuliFizikuri", customer.iuridiuli_fizikuri);
                cmd.Parameters.AddWithValue("@Gvari", customer.gvari);
                cmd.Parameters.AddWithValue("@Saxeli", customer.saxeli);
                cmd.Parameters.AddWithValue("@Qalaqi", customer.qalaqi);
                cmd.Parameters.AddWithValue("@Regioni", customer.regioni);
                cmd.Parameters.AddWithValue("@Raioni", customer.raioni);
                cmd.Parameters.AddWithValue("@Sqesi", customer.sqesi);
                cmd.Parameters.AddWithValue("@Misamarti", customer.misamarti);
                cmd.Parameters.AddWithValue("@Mobiluri", customer.mobiluri);
                cmd.Parameters.AddWithValue("@FirmisDasaxeleba", customer.firmis_dasaxeleba);
                cmd.Parameters.AddWithValue("@MobiluriDireqtoris", customer.mobiluri_direqtoris);
                cmd.Parameters.AddWithValue("@GvariDireqtoris", customer.gvari_direqtoris);
                cmd.Parameters.AddWithValue("@SabankoAngarishi", customer.sabanko_angarishi);
                cmd.Parameters.AddWithValue("@Email", customer.email);

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
                    customer.shemkvetiID = rdr["ShemkvetiID"].ToString();
                    customer.personaliID = rdr["PersonaliID"].ToString();
                    customer.iuridiuli_fizikuri = rdr["IuridiuliFizikuri"].ToString();
                    customer.gvari = rdr["Gvari"].ToString();
                    customer.saxeli = rdr["Saxeli"].ToString();
                    customer.qalaqi = rdr["Qalaqi"].ToString();
                    customer.regioni = rdr["Regioni"].ToString();
                    customer.raioni = rdr["Raioni"].ToString();
                    customer.sqesi = rdr["Sqesi"].ToString();
                    customer.misamarti = rdr["Misamarti"].ToString();
                    customer.mobiluri = rdr["Mobiluri"].ToString();
                    customer.firmis_dasaxeleba = rdr["FirmisDasaxeleba"].ToString();
                    customer.mobiluri_direqtoris = rdr["MobiluriDireqtoris"].ToString();
                    customer.gvari_direqtoris = rdr["GvariDireqtoris"].ToString();
                    customer.sabanko_angarishi = rdr["SabankoAngarishi"].ToString();
                    customer.email = rdr["Email"].ToString();
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
