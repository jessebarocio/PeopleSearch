using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearch.Data
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        [MaxLength(2, ErrorMessage = "Please use the 2-character state code.")]
        public string State { get; set; }
        [MaxLength(5, ErrorMessage = "Please use the 5-digit zip code.")]
        public string Zip { get; set; }
        [Range(0, 150, ErrorMessage = "Please enter a valid age.")]
        public int Age { get; set; }
        public string Interests { get; set; }
    }
}
