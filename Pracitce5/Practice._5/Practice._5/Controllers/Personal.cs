using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace ExcelImportExport.Controllers
{
    public class Personal
    {
        public int Id { get; set; }
        [DisplayName("??????")]
        public string FirstName { get; set; }
        [DisplayName("?????")]
        public string LastName { get; set; }
        [DisplayName("?????")]
        public int Age { get; set; }
    }
}
