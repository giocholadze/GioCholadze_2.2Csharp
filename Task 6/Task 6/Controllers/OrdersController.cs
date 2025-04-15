using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Task_6.Models;
using ClosedXML.Excel;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Task_6.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        
        private readonly string _connectionString;

        public OrdersController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ShekvetaDB");
        }

        [HttpGet("ExportData")]
        public IActionResult ExportData()
        {
            List<Order> orders = GetOrdersForExport();
            MemoryStream excelFile = GenerateExcel(orders);
            return File(excelFile, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "OrdersExport.xlsx");
        }

        private List<Order> GetOrdersForExport()
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
                            shesruleba = reader["shesruleba"].ToString(),
                            visi_mizezit = reader["visi_mizezit"].ToString()
                        };

                        DateTime? tarigiDawyebis = reader["tarigi_dawyebis"] as DateTime?;
                        DateTime? tarigiShesrulebis = reader["tarigi_shesrulebis"] as DateTime?;
                        DateTime? tarigiDamtavrebis = reader["tarigi_damtavrebis"] as DateTime?;

                        if (tarigiShesrulebis.HasValue)
                        {
                            tarigiShesrulebis = new DateTime(DateTime.Now.Year, tarigiShesrulebis.Value.Month, tarigiShesrulebis.Value.Day);
                        }

                        orders.Add(order);
                    }
                }
            }

            return orders;
        }

        private MemoryStream GenerateExcel(List<Order> values)
        {
            using (XLWorkbook workbook = new XLWorkbook())
            {
                IXLWorksheet worksheet = workbook.Worksheets.Add(typeof(Order).Name);
                worksheet = AddHead(worksheet);
                worksheet = AddBody(worksheet, values);
                MemoryStream memoryStream = new MemoryStream();
                workbook.SaveAs(memoryStream);
                memoryStream.Position = 0;
                return memoryStream;
            }
        }

        private IXLWorksheet AddHead(IXLWorksheet worksheet)
        {
            PropertyInfo[] properties = typeof(Order).GetProperties();
            for (int i = 1; i <= properties.Length; i++)
            {
                var attributes = properties[i].GetCustomAttributes(typeof(DisplayNameAttribute), false);
                worksheet.Cell(1, i).Value = attributes.Length > 0 ? ((DisplayNameAttribute)attributes[0]).DisplayName : properties[i].Name;
            }
            return worksheet;
        }

        private IXLWorksheet AddBody(IXLWorksheet worksheet, List<Order> info)
        {
            PropertyInfo[] properties = typeof(Order).GetProperties();
            for (int i = 0; i < info.Count; i++)
            {
                for (int j = 0; j < properties.Length; j++)
                {
                    var propertyInfo = properties[j].GetValue(info[i], null);
                    worksheet.Cell(2 + i, 1 + j).Value = propertyInfo.ToString();
                }
            }
            return worksheet;
        }
    }
}
