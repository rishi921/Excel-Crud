using ExcelCRUDWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using ExcelCRUDWebAPI.Services;
using ExcelCRUDWebAPI.Models;
namespace ExcelCRUDWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DatasetsController : ControllerBase
    {
        private readonly ExcelServices _ExcelServices;

        public DatasetsController(ExcelServices excelServices)
        {
            _ExcelServices = excelServices;

        }

        [HttpGet]
        public ActionResult<List<PersonalInfo>> Get()
        {
            return _ExcelServices.ReadExcelData();
        }

        [HttpPost]
        public IActionResult Post([FromBody] PersonalInfo info)
        {
            _ExcelServices.AddExcelData(info);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put([FromBody] PersonalInfo info)
        {
            _ExcelServices.UpdateExcelData(info);
            return Ok();
        }

        [HttpDelete("{aadharCardNumber}")]
        public IActionResult Delete(string aadharCardNumber)
        {
            _ExcelServices.DeleteExcelData(aadharCardNumber);
            return Ok();
        }
    }

}
