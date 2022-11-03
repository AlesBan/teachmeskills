using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebAPI_10._25DZ.Helpers;
using WebAPI_10._25DZ.Interfaces;

namespace WebAPI_10._25DZ.Controllers
{
    public class HomeControllers : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IJsonIteractor _jsonIteractor;
        public HomeControllers(IConfiguration config, IJsonIteractor iteractor)
        {
            _config = config;
            _jsonIteractor = iteractor;
        }

        [HttpGet("FilePath")]
        public string GetFilePath()
        {
            return MyConfiguration.GetData(_config, "FilePath");
        }

        [HttpGet("FileData")]
        public IEnumerable<Person> GetFileData()
        {
            return _jsonIteractor.JsonReadList(_config);
        }

        [HttpPut("PutDataInFile")]
        public void PutDataInFile()
        {
            _jsonIteractor.JsonWriteList(_config, Constants.people);
        }
    }
}
