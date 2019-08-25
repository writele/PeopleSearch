using PeopleSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleSearch.Repositories
{
    public class PersonRepositoryFake
    {
        private readonly List<Person> _persons;

        public PersonRepositoryFake()
        {
            _persons = new List<Person>()
            {
                new Person() { PersonId = 1,
                    FirstName = "Bruce", LastName = "Wayne"}
            };
        }

        public Person Add(Person person, Address address, List<Interest> interests)
        {
            return person;
        }

        public List<Person> GetAll()
        {
            return _persons;
        }
    }
}
