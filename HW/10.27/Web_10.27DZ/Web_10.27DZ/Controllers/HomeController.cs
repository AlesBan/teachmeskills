using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PersonEnv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_10._27DZ.DIEnv;
using Web_10._27DZ.Helpers;
using Web_10._27DZ.Interfaces;
using Web_10._27DZ.PersonEnv;

namespace Web_10._27DZ.Controllers
{
    [Route("people")]
    public class HomeController : ControllerBase
    {
        private readonly IPeopleStorage _peopleStorage;
        private readonly DI dI;
        public HomeController(IConfiguration configuration, IJsonIteractor jsonIteractor, IPeopleStorage peopleStorage)
        {
            _peopleStorage = peopleStorage;
            dI = new DI(configuration, jsonIteractor);
        }

        [HttpGet("all-people")]
        public IActionResult GetPeople()
        {
            return Ok(_peopleStorage.InnerCol);
        }

        [HttpPost("create-new-person")]
        public IActionResult PutPerson([FromBody] PersonDto personDto)
        {
            Person newPerson = new Person(personDto.Name, personDto.Age);
            _peopleStorage.Add(newPerson);
            _peopleStorage.Save(dI);
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
                return Ok(_peopleStorage.InnerCol.Where(x => x.id == id).ToList()[0]);
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
                _peopleStorage.Save(dI);
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
                _peopleStorage.Save(dI);
                return Ok();
            }
        }
    }
}
