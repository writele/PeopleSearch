using PeopleSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleSearch.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersonContext _context;

        public PersonRepository(PersonContext context)
        {
            _context = context;
        }

        public Person Get(int id)
        {
            return _context.Persons
                .Where(x => x.PersonId == id)
                .FirstOrDefault();
        }

        public List<Interest> GetInterests(int id)
        {
            return _context.Persons
                .Where(p => p.PersonId == id)
                .SelectMany(p => p.PersonInterests)
                .Select(pi => pi.Interest)
                .ToList();
        }

        public List<string> GetInterests()
        {
            return _context.Interests.Select(x => x.Title).ToList();
        }

        public Address GetAddress(int id)
        {
            return _context.Addresses
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public List<Person> GetAll()
        {
            return _context.Persons.ToList();
        }

        public Person Add(PersonViewModel person)
        {
            var newPerson = new Person();
            newPerson.FirstName = person.FirstName;
            newPerson.LastName = person.LastName;
            newPerson.Age = person.Age;
            newPerson.ImageUrl = person.ImageUrl;

            var newAddress = new Address();
            newAddress.Address1 = person.Address1;
            newAddress.Address2 = person.Address2;
            newAddress.City = person.City;
            newAddress.State = person.State;
            newAddress.ZipCode = person.ZipCode;
            _context.Addresses.Add(newAddress);

            newPerson.AddressId = newAddress.Id;

            foreach (var item in person.Interests)
            {
                _context.PersonInterests.Add(new PersonInterest()
                {
                    PersonId = newPerson.PersonId,
                    InterestId = _context.Interests
                    .Where(x => x.Title == item)
                    .FirstOrDefault().InterestId,
                    Interest = _context.Interests
                    .Where(x => x.Title == item)
                    .FirstOrDefault()
                });
            }

            if (person != null)
            {
                _context.Persons.Add(newPerson);
                _context.SaveChanges();

                return newPerson;
            }

            return null;
        }
    }
}
