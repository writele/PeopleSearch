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
        public DbSet<PersonInterest> PersonInterests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonInterest>()
                .HasKey(t => new { t.PersonId, t.InterestId });

            modelBuilder.Entity<PersonInterest>()
                .HasOne<Person>(e => e.Person)
                .WithMany(p => p.PersonInterests);

            modelBuilder.Entity<PersonInterest>()
                .HasOne<Interest>(e => e.Interest)
                .WithMany(p => p.PersonInterests);

            modelBuilder.Entity<Person>()
                .HasOne<Address>(p => p.Address)
                .WithOne(s => s.Person)
                .HasForeignKey<Person>(ad => ad.PersonId);

            var interest1 = new Interest
            {
                InterestId = 1,
                Title = "Books"
            };

            var interest2 = new Interest
            {
                InterestId = 2,
                Title = "Writing"
            };

            var interest3 = new Interest
            {
                InterestId = 3,
                Title = "Movies"
            };

            var interest4 = new Interest
            {
                InterestId = 4,
                Title = "Sports"
            };

            var interest5 = new Interest
            {
                InterestId = 5,
                Title = "Hiking"
            };

            var interest6 = new Interest
            {
                InterestId = 6,
                Title = "Travel"
            };

            var interest7 = new Interest
            {
                InterestId = 7,
                Title = "Animals"
            };

            var interest8 = new Interest
            {
                InterestId = 8,
                Title = "Video Games"
            };

            var interest9 = new Interest
            {
                InterestId = 9,
                Title = "Board Games"
            };

            modelBuilder.Entity<Interest>().HasData(
                interest1, interest2, interest3, interest4, interest5, interest6, interest7, interest8, interest9
            );

            var address1 = new Address
            {
                Id = 1,
                Address1 = "1000 Wayne Manor Dr.",
                City = "Gotham",
                State = "NJ",
                ZipCode = 22222
            };

            var address2 = new Address
            {
                Id = 2,
                Address1 = "404 7th St.",
                Address2 = "Apt. 603",
                City = "National City",
                State = "WA",
                ZipCode = 54545
            };

            var address3 = new Address
            {
                Id = 3,
                Address1 = "1200 Main Ave.",
                Address2 = "Suite 300",
                City = "New York City",
                State = "NY",
                ZipCode = 72172
            };

            var address4 = new Address
            {
                Id = 4,
                Address1 = "1418 Trade St.",
                Address2 = "Apt 1606",
                City = "Metropolis",
                State = "PA",
                ZipCode = 72172
            };

            var address5 = new Address
            {
                Id = 5,
                Address1 = "1333 West Sharon St.",
                City = "Gotham",
                State = "NJ",
                ZipCode = 22244
            };

            var address6 = new Address
            {
                Id = 6,
                Address1 = "300 MLK Blvd.",
                Address2 = "Apt 1602",
                City = "Central City",
                State = "CA",
                ZipCode = 77777
            };

            var address7 = new Address
            {
                Id = 7,
                Address1 = "2600 Ocean Ave",
                City = "Coast City",
                State = "WA",
                ZipCode = 51255
            };

            modelBuilder.Entity<Address>().HasData(
                address1, address2, address3, address4, address5, address6, address7
            );

            var person1 = new Person
            {
                PersonId = 1,
                FirstName = "Bruce",
                LastName = "Wayne",
                Age = 37,
                AddressId = 1,
                ImageUrl = "/images/bwayne.jpg"
            };

            var person2 = new Person
            {
                PersonId = 2,
                FirstName = "Kara",
                LastName = "Danvers",
                Age = 22,
                AddressId = 2,
                ImageUrl = "/images/kdanvers.jpg"
            };

            var person3 = new Person
            {
                PersonId = 3,
                FirstName = "Diana",
                LastName = "Prince",
                Age = 54,
                AddressId = 3,
                ImageUrl = "/images/dprince.jpg"
            };

            var person4 = new Person
            {
                PersonId = 4,
                FirstName = "Clark",
                LastName = "Kent",
                Age = 35,
                AddressId = 4,
                ImageUrl = "/images/ckent.jpg"
            };

            var person5 = new Person
            {
                PersonId = 5,
                FirstName = "Barbara",
                LastName = "Gordon",
                Age = 25,
                AddressId = 5,
                ImageUrl = "/images/bgordon.jpg"
            };

            var person6 = new Person
            {
                PersonId = 6,
                FirstName = "Barry",
                LastName = "Allen",
                Age = 27,
                AddressId = 6,
                ImageUrl = "/images/ballen.jpg"
            };

            var person7 = new Person
            {
                PersonId = 7,
                FirstName = "John",
                LastName = "Stewart",
                Age = 34,
                AddressId = 7,
                ImageUrl = "/images/jstewart.jpg"
            };

            modelBuilder.Entity<Person>().HasData(
                person1, person2, person3, person4, person5, person6, person7
            );

            modelBuilder.Entity<PersonInterest>()
            .HasData(
                new PersonInterest { PersonId = 1, InterestId = 1 },
                new PersonInterest { PersonId = 1, InterestId = 4 },
                new PersonInterest { PersonId = 1, InterestId = 6 },

                new PersonInterest { PersonId = 2, InterestId = 2 },
                new PersonInterest { PersonId = 2, InterestId = 3 },
                new PersonInterest { PersonId = 2, InterestId = 9 },

                new PersonInterest { PersonId = 3, InterestId = 5 },
                new PersonInterest { PersonId = 3, InterestId = 6 },
                new PersonInterest { PersonId = 3, InterestId = 7 },

                new PersonInterest { PersonId = 4, InterestId = 3 },
                new PersonInterest { PersonId = 4, InterestId = 4 },
                new PersonInterest { PersonId = 4, InterestId = 8 },

                new PersonInterest { PersonId = 5, InterestId = 1 },
                new PersonInterest { PersonId = 5, InterestId = 8 },

                new PersonInterest { PersonId = 6, InterestId = 1 },
                new PersonInterest { PersonId = 6, InterestId = 8 },
                new PersonInterest { PersonId = 6, InterestId = 2 },
                new PersonInterest { PersonId = 6, InterestId = 4 },

                new PersonInterest { PersonId = 7, InterestId = 4 }
                );
        }
    }
}
