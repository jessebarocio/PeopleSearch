using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearch.Data
{
    /// <summary>
    /// A database initializer that seeds some Person/Photo data when the database is created.
    /// </summary>
    class CreateAndSeedDatabaseIfNotExists : CreateDatabaseIfNotExists<PeopleSearchContext>
    {
        protected override void Seed(PeopleSearchContext context)
        {
            foreach (var person in GetSeedPeople())
            {
                // Add their photo to the database
                var photo = new Photo()
                {
                    ContentType = "image/png",
                    Data = GetEmbeddedResourceBytes(
                        String.Format("PeopleSearch.Data.SeedData.{0}-{1}.png", person.FirstName, person.LastName))
                };
                context.Photos.Add(photo);
                context.SaveChanges();
                // Link the photo to the person.
                person.PhotoId = photo.PhotoId;
                context.People.Add(person);
                context.SaveChanges(); 
            }
            base.Seed(context);
        }

        private static IEnumerable<Person> GetSeedPeople()
        {
            return JsonConvert.DeserializeObject<IEnumerable<Person>>(
                GetEmbeddedResourceString("PeopleSearch.Data.SeedData.People.json"));
        }

        private static string GetEmbeddedResourceString(string resourceName)
        {
            using (Stream s = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            using (StreamReader sr = new StreamReader(s))
            {
                return sr.ReadToEnd();
            }
        }

        private static byte[] GetEmbeddedResourceBytes(string resourceName)
        {
            using (Stream s = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            using (MemoryStream ms = new MemoryStream())
            {
                s.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}
