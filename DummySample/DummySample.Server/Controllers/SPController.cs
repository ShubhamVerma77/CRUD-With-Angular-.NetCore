using DummySample.Server.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DummySample.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SPController : ControllerBase
    {
        private readonly ISP _spservice;
        public SPController(ISP spservice)
        {
            _spservice = spservice;
        }

        [HttpGet("GetDataFromSP")]
        public async Task<IActionResult> GetAllAsync()
        {
            var Result = await _spservice.GetAllAsync();
            if (Result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Result);
            }
        }
    }
}
