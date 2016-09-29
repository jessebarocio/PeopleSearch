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
    public class PersonApiController : ApiController
    {
        private IPersonRepository _repository;

        public PersonApiController() { }

        public PersonApiController(IPersonRepository repo)
        {
            _repository = repo;
        }

        [HttpGet, Route("search/{searchStr}")]
        public async Task<IEnumerable<Person>> SearchByNameAsync(string searchStr)
        {
            return await _repository.SearchByNameAsync(searchStr);
        }
    }
}
