using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearch.Data
{
    public class Photo
    {
        public int PhotoId { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
    }
}
