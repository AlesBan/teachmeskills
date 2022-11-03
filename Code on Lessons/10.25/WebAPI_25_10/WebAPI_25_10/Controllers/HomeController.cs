using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_25_10.Interfaces;

namespace WebAPI_25_10.Controllers
{
    [ApiController]
    [Route("home")]
    public class HomeController : ControllerBase
    {
        public readonly IHomeService _homeService;
        public readonly IConfiguration _config;
        public HomeController(IHomeService homeService, IConfiguration config)
        {
            _homeService = homeService;
            _config = config;
        }
         
        [HttpGet("say")]
        public string say()
        {
            return _homeService.SaySMT();
        }

        [HttpGet("secret-key/{id:int}")]
        public ActionResult<ComplexSetting> GetKey(int id, string param)
        {
            return BadRequest();
        }

        [HttpGet("save-new-data")]
        public ComplexSetting SaveData(BasicData data)
        {
            return _config.GetSection("ComplexSettings").Get<ComplexSetting>();
        }

    }

}
