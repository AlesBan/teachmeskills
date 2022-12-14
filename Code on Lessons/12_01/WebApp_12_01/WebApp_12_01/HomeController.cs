using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_12_01.Models;

namespace WebApp_12_01
{
    public class HomeController : Controller
    {

        private readonly TestContext _testContext;
        public HomeController(TestContext testContext)
        {
            _testContext = testContext;
        }
        [HttpGet("/{age:int}")]
        public IEnumerable<Person> Get([FromRoute] int age)
        {
            return _testContext.Persons.Where(x => x.Age > age);
        }
        

        [HttpPut("{id:guid}")]
        public async Task<Person> UpdatePerson([FromRoute] Guid id, [FromBody] int age)
        {
            var person = await _testContext.Persons.FirstOrDefaultAsync(x => x.Id == id);
            person.Age = age;
            await _testContext.SaveChangesAsync();
            _testContext.Persons.Add(person);
            return person;
        }

        [HttpPost]
        public async Task<Person> CreatePerson([FromBody] Person person)
        {
            var tranzaction = await _testContext.Database.BeginTransactionAsync();
             _testContext.Persons.Add(person);

            await _testContext.SaveChangesAsync();
            await _testContext.SaveChangesAsync();
            await _testContext.SaveChangesAsync();
            await _testContext.SaveChangesAsync();

            await tranzaction.CommitAsync();
            return person;
        }
    }
}
