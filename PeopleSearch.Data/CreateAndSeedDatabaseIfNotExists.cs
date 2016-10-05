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
    class CreateAndSeedDatabaseIfNotExists : CreateDatabaseIfNotExists<PeopleSearchContext>
    {
        protected override void Seed(PeopleSearchContext context)
        {
            foreach (var person in GetSeedData())
            {
                person.Photo = new Photo()
                {
                    ContentType = "image/png",
                    Data = GetEmbeddedResourceBytes(
                        String.Format("PeopleSearch.Data.SeedData.{0}-{1}.png", person.FirstName, person.LastName))
                };
                context.People.Add(person);
            }
            context.SaveChanges();
            base.Seed(context);
        }

        private IEnumerable<Person> GetSeedData()
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
