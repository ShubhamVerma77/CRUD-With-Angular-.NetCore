using DummySample.Server.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static DummySample.Server.TestModel.ParameterModel;

namespace DummySample.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DTController : ControllerBase
    {
        private readonly IDT _dtservice;
        public DTController(IDT service)
        {
            _dtservice = service;
        }

        [HttpPost("InsertByDT")]
        public async Task<IActionResult> InsertDataByDT(InsertDataParamsmodel model)
        {
            var result = await _dtservice.InsertDataByDT(model);
            if(result!=null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("UpdateByDT")]
        public async Task<IActionResult> UpdateByDT(UpdateParamModel model)
        {
            var Result = await _dtservice.UpdateByDT(model);
            if(Result!=null)
            {
                return Ok(Result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("DeleteDataByDT")]
          public async Task<IActionResult> DeleteByDT(DeleteParamModel model)
        {
            var Result = await _dtservice.DeleteByDT(model);
            if(Result!=null)
            {
                return Ok(Result);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
