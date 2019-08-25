using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleSearch.Models
{
    public class Interest
    {
        public int InterestId { get; set; }

        public string Title { get; set; }

        public virtual ICollection<PersonInterest> PersonInterests { get; set; }
    }
}
