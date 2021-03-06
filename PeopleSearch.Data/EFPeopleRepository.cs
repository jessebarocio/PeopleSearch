﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearch.Data
{
    /// <summary>
    /// An EntityFramework implementation of IPeopleRepository.
    /// </summary>
    public class EFPeopleRepository : IPeopleRepository
    {
        PeopleSearchContext context;

        public EFPeopleRepository()
        {
            context = new PeopleSearchContext();
        }

        public Task<IEnumerable<Person>> SearchByNameAsync(string searchString)
        {
            // EF6 still doesn't support async queries. Wrap the result in a Task since the interface requires it.
            return Task.FromResult<IEnumerable<Person>>(
                context.People.Where(p => p.FirstName.Contains(searchString) || p.LastName.Contains(searchString))
                    .ToList());
        }

        public async Task<Person> InsertPersonAsync(Person p)
        {
            context.People.Add(p);
            await context.SaveChangesAsync();
            return p;
        }

        public Task<Person> GetPersonAsync(int id)
        {
            return context.People.FindAsync(id);
        }

        #region IDisposable Implementation

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (context != null)
                {
                    context.Dispose();
                    context = null;
                }
            }
        }

        #endregion
    }
}
