using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PersonEnv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_10._27DZ.Helpers;
using Web_10._27DZ.Interfaces;
using Web_10._27DZ.PersonEnv;

namespace Web_10._27DZ.Controllers
{
    [Route("People")]
    public class HomeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IJsonIteractor _jsonIteractor;
        private readonly IPeopleStorage _peopleStorage;
        public HomeController(IConfiguration configuration, IJsonIteractor jsonIteractor, IPeopleStorage peopleStorage)
        {
            _configuration = configuration;
            _jsonIteractor = jsonIteractor;
            _peopleStorage = peopleStorage;
        }

        [HttpPost("PutPeople")]
        public IActionResult PutPeople()
        {
            _jsonIteractor.JsonWriteList(_configuration, Constants.people);
            return new EmptyResult();
        }

        [HttpGet("GetPeople")]
        public IActionResult GetPeople()
        {
            _peopleStorage.innerCol = _jsonIteractor.JsonReadList(_configuration);
            return new ObjectResult(_jsonIteractor.JsonReadList(_configuration));
        }

        [HttpGet("{personId:int}")]
        public IActionResult GetPerson([FromRoute] int personId)
        {
            ObjectResult objectResult = new ObjectResult(_jsonIteractor.JsonReadList(_configuration)[personId - 1]);
            return Ok(objectResult);
        }

        [HttpDelete("DeletePerson")]
        public IActionResult DeletePerson([FromRoute] int id)
        {
            IPerson person = _peopleStorage.innerCol[id - 1];
            _peopleStorage.Remove(person);
            return Ok(person);
        }
        [HttpPost("PutPerson")]
        public IActionResult PutPerson([FromRoute] string Name, [FromRoute] int Age)
        {
            _peopleStorage.Add(new Person(Name, Age));
            return Ok();
        }

        [HttpPut("UpdatePerson")]
        public IActionResult UpdatePerson([FromRoute] int id, [FromRoute] string Name, [FromRoute] int Age)
        {
            _peopleStorage.UpDate(id, new Person(Name, Age));
            return Ok();

        }
    }
}
