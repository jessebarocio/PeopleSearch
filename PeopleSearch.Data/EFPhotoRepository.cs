using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearch.Data
{
    /// <summary>
    /// An EntityFramework implementation of IPhotoRepository. 
    /// 
    /// NOTE: This class is separate from EFPeopleRepository in order to swap out implementations. I wouldn't normally use EF to 
    /// store files. An S3 bucket, Azure Blob container, or a database built for storing files like GridFS are all better options.
    /// </summary>
    public class EFPhotoRepository : IPhotoRepository
    {
        PeopleSearchContext context;

        public EFPhotoRepository()
        {
            context = new PeopleSearchContext();
        }

        public Task<Photo> GetPhotoAsync(int id)
        {
            return context.Photos.FindAsync(id);
        }
    }
}
