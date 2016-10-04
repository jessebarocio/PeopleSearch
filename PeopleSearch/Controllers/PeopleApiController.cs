using PeopleSearch.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PeopleSearch.Controllers
{
    [RoutePrefix("api/people")]
    public class PeopleApiController : ApiController
    {
        private IPeopleRepository _repository;

        public PeopleApiController() : this(new EFPeopleRepository()) { }

        public PeopleApiController(IPeopleRepository repo)
        {
            _repository = repo;
        }

        [HttpGet, Route("search/{searchStr}")]
        public async Task<IEnumerable<Person>> SearchByNameAsync(string searchStr)
        {
            return await _repository.SearchByNameAsync(searchStr);
        }

        [HttpPost, Route("")]
        public async Task<Person> PostPersonAsync(Person person)
        {
            return await _repository.InsertPersonAsync(person);
        }
    }
}
