﻿using Newtonsoft.Json;
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
    public class PeopleSearchContext : DbContext
    {
        public PeopleSearchContext() : base("name=PeopleSearchContext")
        {
            // Register initializer which will create the database and seed data if it does not exist.
            Database.SetInitializer(new CreateAndSeedDatabaseIfNotExists());
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }
}
