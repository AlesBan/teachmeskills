using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TableDataTypes;
using TableDataTypes.Iteraction;
using TableDataTypes.JsonIteraction;
using TableDataTypes.Person;

namespace AspWebApi.Controllers
{
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {

        [HttpGet]
        public Table<string, int, Address> Get()
        {
            return JsonIteractor.JsonRead();
        }
        [HttpGet("putPeople")]
        public void PutPeople()
        {
            JsonIteractor.JsonWrite(IteractionWithUser.PutDefaultLines());

        }
    }
}
