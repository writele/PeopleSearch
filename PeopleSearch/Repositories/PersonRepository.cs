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
            return _context.Persons.Where(x => x.PersonId == id).FirstOrDefault();
        }

        public List<Interest> GetInterests(int id)
        {
            return _context.Persons
                .Where(p => p.PersonId == id)
                .SelectMany(p => p.PersonInterests)
                .Select(pc => pc.Interest)
                .ToList();
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

        public Person Add(Person person, Address address, List<Interest> interests)
        {
            person.Address = address;

            foreach (var item in interests)
            {
                _context.PersonInterests.Add(new PersonInterest()
                {
                    PersonId = person.PersonId,
                    InterestId = item.InterestId,
                    Interest = _context.Interests.Where(x => x.InterestId == item.InterestId).FirstOrDefault()
                });
            }

            if (person != null)
            {
                _context.Persons.Add(person);
                _context.SaveChanges();

                return person;
            }

            return null;
        }
    }
}
