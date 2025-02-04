using DummySample.Server.Interface;
using DummySample.Server.Model;
using DummySample.Server.TestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static DummySample.Server.TestModel.ParameterModel;

namespace DummySample.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly IDemo _demoservice;
        public DemoController(IDemo demoservice)
        {
            _demoservice = demoservice;
        }

        [HttpPost("SaveData")]
        public async Task<IActionResult> PostData(Demo demo)
        {
            var Result = await _demoservice.PostData(demo);
            if(Result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Result);
            }
        }

        [HttpGet("GetAllData")]
        public async Task<IActionResult> GetData()
        {
            var Data = await _demoservice.GetData();
            if(Data == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Data);
            }
        }

        [HttpPost("GetDataById")]
        public async Task<IActionResult> GetDataById(GetBYIDModel model)
        {
            var Data = await _demoservice.GetDataById(model);
            if(Data == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Data);
            }
        }

        [HttpPost("DeleteData")]
        public async Task<IActionResult> DeleteData(DeleteModel model)
        {
            var Rseult = await _demoservice.DeleteData(model);
            if (Rseult == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Rseult);
            }
        }

        [HttpPost("UpdateData")]

        public async Task<IActionResult> UpdateData(UpadteModel model)
        {
            var Result = await _demoservice.UpdateData(model);
            if(Result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Result);
            }
        }

        [HttpPost("DeleteAllData")]
        public async Task<IActionResult> DeleteAllData()
        {
            var Result = await _demoservice.DeleteAllData();
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
