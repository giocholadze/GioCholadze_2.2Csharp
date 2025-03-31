using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using Task_6.Models;

namespace Task_6.Services
{
    public class OrderService
    {
        private readonly string _connectionString;

        public OrderService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Order> GetOrdersForExport()
        {
            List<Order> orders = new List<Order>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
                    SELECT 
                        xelshekrulebaID, shemkvetiID, gadasaxdeli_l, gadasaxdeli_d, 
                        gadaxdili_l, gadaxdili_d, vali_l, vali_d, kursi, 
                        tarigi_dawyebis, tarigi_shesrulebis, tarigi_damtavrebis, 
                        shesruleba, visi_mizezit 
                    FROM Orders 
                    WHERE tarigi_damtavrebis IS NULL OR tarigi_damtavrebis = ''";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var order = new Order
                        {
                            xelshekrulebaID = reader["xelshekrulebaID"].ToString(),
                            shemkvetiID = reader["shemkvetiID"].ToString(),
                            gadasaxdeli_l = reader["gadasaxdeli_l"].ToString(),
                            gadasaxdeli_d = reader["gadasaxdeli_d"].ToString(),
                            gadaxdili_l = reader["gadaxdili_l"].ToString(),
                            gadaxdili_d = reader["gadaxdili_d"].ToString(),
                            vali_l = reader["vali_l"].ToString(),
                            vali_d = reader["vali_d"].ToString(),
                            kursi = reader["kursi"].ToString(),
                            tarigi_dawyebis = reader["tarigi_dawyebis"].ToString(),
                            tarigi_shesrulebis = reader["tarigi_shesrulebis"].ToString(),
                            tarigi_damtavrebis = reader["tarigi_damtavrebis"].ToString(),
                            shesruleba = reader["shesruleba"].ToString(),
                            visi_mizezit = reader["visi_mizezit"].ToString()
                        };
                        DateTime endDate = Convert.ToDateTime(order.tarigi_shesrulebis);
                        order.tarigi_shesrulebis = new DateTime(DateTime.Now.Year, endDate.Month, endDate.Day).ToString("yyyy-MM-dd");
                        order.DaysLeft = (order.tarigi_shesrulebis - DateTime.Now).;

                        orders.Add(order);
                    }
                }
            }

            return orders;
        }
    }
}
