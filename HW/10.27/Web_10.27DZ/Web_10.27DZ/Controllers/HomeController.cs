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
    [Route("people")]
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

        [HttpGet("all-people")]
        public IActionResult GetPeople()
        {
            _peopleStorage.InnerCol = _jsonIteractor.JsonReadList(_configuration);
            return new ObjectResult(_jsonIteractor.JsonReadList(_configuration));
        }

        [HttpPost("create-new-person")]
        public IActionResult PutPerson([FromBody] PersonDto personDto)
        {
            Person newPerson = new Person(personDto.Name, personDto.Age);
            _peopleStorage.Add(newPerson);
            _peopleStorage.WriteDataInFile(_jsonIteractor, _configuration);
            return Ok(newPerson);
        }

        [HttpGet("{id:Guid}")]
        public IActionResult GetPerson([FromRoute] Guid? id)
        {
            if (!_peopleStorage.Contains((Guid)id))
            {
                return NotFound();
            }
            else
            {
                ObjectResult objectResult = new ObjectResult(_peopleStorage.InnerCol.Where(x => x.id == id).ToList()[0]);
                _peopleStorage.WriteDataInFile(_jsonIteractor, _configuration);
                return Ok(objectResult);
            }
        }

        [HttpDelete("{id:Guid}")]
        public IActionResult DeletePerson([FromRoute] Guid? id)
        {
            if (!_peopleStorage.Contains((Guid)id))
            {
                return NotFound();
            }
            else
            {
                Person person = _peopleStorage.InnerCol.Where(x => x.id == id).ToList()[0];
                _peopleStorage.Remove(person);
                _peopleStorage.WriteDataInFile(_jsonIteractor, _configuration);
                return Ok(person);
            }
        }

        [Route("update-person")]
        [HttpPut]
        public IActionResult UpdatePerson([FromBody] Person person)
        {
            if (!_peopleStorage.Contains(person.id))
            {
                return NotFound();
            }
            else
            {
                _peopleStorage.UpDate(person.id, new Person(person.Name, person.Age));
                _peopleStorage.WriteDataInFile(_jsonIteractor, _configuration);
                return Ok();
            }
        }
    }
}
