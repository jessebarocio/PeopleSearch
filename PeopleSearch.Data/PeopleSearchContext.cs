using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearch.Data
{
    public class PeopleSearchContext : DbContext
    {
        public PeopleSearchContext() : base("name=PeopleSearchContext")
        {

        }
        public DbSet<Person> People { get; set; }
    }
}
