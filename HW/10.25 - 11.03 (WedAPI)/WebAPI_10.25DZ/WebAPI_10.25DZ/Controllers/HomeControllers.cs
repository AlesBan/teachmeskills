using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebAPI_10._25DZ.FileIteraction;
using WebAPI_10._25DZ.Helpers;
using WebAPI_10._25DZ.Interfaces;

namespace WebAPI_10._25DZ.Controllers
{
    public class HomeControllers : ControllerBase
    {
        private readonly IConfiguration _config;
        public HomeControllers(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet("FilePath")]
        public string GetFilePath()
        {
            return MyConfiguration.GetData(_config, "FilePath");
        }

        [HttpGet("FileData")]
        public string GetFileData()
        {
            return JsonIteractor.JsonRead(_config)?.ToString();
        }
        [HttpPut("PutDataInFile")]
        public void PutDataInFile()
        {
            JsonIteractor.JsonWrite(_config, new Person("Ales", 19));
        }
    }
}
