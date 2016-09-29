using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearch.Data
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> SearchByNameAsync(string searchString);
    }
}
