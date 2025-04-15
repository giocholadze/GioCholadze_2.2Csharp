using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Practice_7.Models;
using System;
using System.IO;

namespace Practice_7.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ApplicationController : Controller
    {
        [HttpPost]
        public IActionResult ExportData(IFormFile data)
        {
            if (data == null || data.Length == 0 || !data.FileName.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("Incorrect format. Please upload a JSON file.");
            }

            Root root = new Root();

            using (MemoryStream stream = new MemoryStream())
            {
                data.CopyTo(stream);
                stream.Position = 0;

                using (StreamReader reader = new StreamReader(stream))
                {
                    var result = reader.ReadToEnd();
                    root = JsonConvert.DeserializeObject<Root>(result);
                }
            }

            WorkWithExcel<Event> workWithExcel1 = new WorkWithExcel<Event>();
            WorkWithExcel<Customer> workWithExcel2 = new WorkWithExcel<Customer>();

            using (XLWorkbook wb = new XLWorkbook())
            {
                var ws1 = workWithExcel1.AddHeader(wb, root.Events);
                workWithExcel1.AddBody(ws1, root.Events);

                var ws2 = workWithExcel2.AddHeader(wb, root.Customers);
                workWithExcel2.AddBody(ws2, root.Customers);

                using (MemoryStream outputStream = new MemoryStream())
                {
                    wb.SaveAs(outputStream);
                    outputStream.Position = 0;

                    return File(outputStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Test1.xlsx");
                }
            }
        }
    }
}
