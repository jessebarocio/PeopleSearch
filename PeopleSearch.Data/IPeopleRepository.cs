using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearch.Data
{
    public interface IPeopleRepository : IDisposable
    {
        Task<IEnumerable<Person>> SearchByNameAsync(string searchString);
        Task<Person> InsertPersonAsync(Person p);
    }
}
