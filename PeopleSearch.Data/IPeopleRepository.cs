using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearch.Data
{
    /// <summary>
    /// A repository for storing/retrieving information about people.
    /// </summary>
    public interface IPeopleRepository : IDisposable
    {
        /// <summary>
        /// Searches the data store for people with names containing the given search string.
        /// </summary>
        /// <param name="searchString">The string to search names for.</param>
        /// <returns>A collection of matching people.</returns>
        Task<IEnumerable<Person>> SearchByNameAsync(string searchString);

        /// <summary>
        /// Adds the given person to the data store.
        /// </summary>
        /// <param name="p">The Person to add.</param>
        /// <returns>The Person that was added.</returns>
        Task<Person> InsertPersonAsync(Person p);

        /// <summary>
        /// Retrieves a person with the given ID.
        /// </summary>
        /// <param name="id">The ID of the Person to retrieve.</param>
        /// <returns>The Person with the given ID.</returns>
        Task<Person> GetPersonAsync(int id);
    }
}
