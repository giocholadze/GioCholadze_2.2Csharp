using Microsoft.AspNetCore.Mvc;
using Task_6.Models;
using Task_6.Services;

namespace Task_6.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _orderService;
        private readonly ExcellService<Order> _excelService;

        public OrdersController(OrderService orderService, ExcellService<Order> excelService)
        {
            _orderService = orderService;
            _excelService = excelService;
        }

        [HttpGet("ExportData")]
        public IActionResult ExportData()
        {
            List<Order> orders = _orderService.GetOrdersForExport();
            MemoryStream excelFile = _excelService.Generate(orders);
            return File(excelFile, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "OrdersExport.xlsx");
        }
    }
}
