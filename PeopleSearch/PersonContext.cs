using Microsoft.EntityFrameworkCore;
using PeopleSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleSearch
{
    public class PersonContext : DbContext
    {

        public PersonContext(DbContextOptions<PersonContext> options)
      : base(options)
        { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Interest> Interests { get; set; }
    }
}
