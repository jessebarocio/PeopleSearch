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
                context.People.Add(person);
            }
            context.SaveChanges();
            base.Seed(context);
        }

        private IEnumerable<Person> GetSeedData()
        {
            return JsonConvert.DeserializeObject<IEnumerable<Person>>(
                GetEmbeddedResourceString("PeopleSearch.Data.SeedData.json"));
        }

        public static string GetEmbeddedResourceString(string resourceName)
        {
            using (Stream s = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            using (StreamReader sr = new StreamReader(s))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
