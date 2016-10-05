using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearch.Data
{
    /// <summary>
    /// A repository for storing/retrieving photos.
    /// </summary>
    public interface IPhotoRepository
    {
        /// <summary>
        /// Retrieves the Photo with the given ID.
        /// </summary>
        /// <param name="id">The ID of the Photo to retrieve.</param>
        /// <returns>The Photo with the given ID.</returns>
        Task<Photo> GetPhotoAsync(int id);
    }
}
