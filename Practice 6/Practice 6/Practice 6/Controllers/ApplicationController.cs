using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Practice_6.Models;
using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace Practice_6.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ApplicationController : Controller
    {
        [HttpPost]
        public Root DeserializeData(IFormFile data)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                data.CopyTo(memoryStream);
                memoryStream.Position = 0;
                using (StreamReader reader = new StreamReader(memoryStream))
                { 
                    var result = reader.ReadToEnd();   
                    Root deserialized = JsonConvert.DeserializeObject<Root>(result.ToString());
                    return deserialized;
                }
            }
        }

    }
}