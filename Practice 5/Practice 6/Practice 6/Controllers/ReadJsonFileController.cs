using Microsoft.AspNetCore.Mvc;

namespace Practice_6.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ReadJsonFileController : ControllerBase
    {
        [HttpGet]
        public IActionResult ImportData(IFormFile file)
        {
            //TODO
            return Ok();
        }
    }
}
