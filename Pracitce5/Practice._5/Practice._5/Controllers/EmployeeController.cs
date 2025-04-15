using Microsoft.AspNetCore.Mvc;
using ClosedXML.Excel;
using Practice5.Models; 
using ExcelImportExport.Controllers; 

namespace Practice._5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly WorkWithExcel<Employee> _excelService;

        public EmployeeController(WorkWithExcel<Employee> excelService)
        {
            _excelService = excelService;
        }

        [HttpPost("exportExcel")]
        public IActionResult ExportExcel([FromBody] List<Employee> employees)
        {
            if (employees == null || employees.Count == 0)
                return BadRequest("No employees data provided.");

            var workbook = _excelService.Generate(employees);

            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                stream.Position = 0;

                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Employees.xlsx");
            }
        }
    }
}
