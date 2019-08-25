using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleSearch.Models
{
    public class Person
    {
        public int PersonId { get; set; }

        [Required, StringLength(80)]
        public string FirstName { get; set; }

        [Required, StringLength(80)]
        public string LastName { get; set; }

        public int Age { get; set; }

        public string ImageUrl { get; set; }

        public int AddressId { get; set; }

        public virtual Address Address { get; set; }

        public virtual ICollection<PersonInterest> PersonInterests { get; set; }
    }
}
