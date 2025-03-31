using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Practice_7.Models;

namespace Practice_7.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }


        [HttpPost("ImportData")]
        public async Task<IActionResult> ImportData(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File was not found or it was incorrect format");
            }

            List<Dictionary<string, string>> result = [];
            // 1 ნატო ჯაფარიძე 25
            // [{"Id":"1","სახელი":"ნატო","გვარი":"ჯაფარიძე","ასაკი":"25"},
            // {"Id":"2","სახელი":"ნატო","გვარი":"ჯაფარიძე","ასაკი":"25"} ,
            // {"Id":"3","სახელი":"ნატო","გვარი":"ჯაფარიძე","ასაკი":"25"} ,
            // {"Id":"4","სახელი":"ნატო","გვარი":"ჯაფარიძე","ასაკი":"25"}]

            using (MemoryStream stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                stream.Position = 0;

                using (XLWorkbook wb = new XLWorkbook(stream))
                {
                    var sheet = wb.Worksheets.First();
                    var rows = sheet.RangeUsed().RowsUsed();

                    var headerRow = rows.First();
                    var headers = headerRow.Cells().Select(x => x.Value.ToString()).ToList();

                    foreach (var row in rows.Skip(1))
                    {
                        Dictionary<string, string> rowData = new Dictionary<string, string>();
                        foreach (var cell in row.Cells())
                        {
                            var header = headers[cell.Address.ColumnNumber - 1];
                            rowData[header] = cell.Value.ToString();
                        }
                        result.Add(rowData);
                    }
                }
                return Ok(result);
            }
        }

    }
}
