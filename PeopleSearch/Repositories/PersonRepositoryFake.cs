using PeopleSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleSearch.Repositories
{
    public class PersonRepositoryFake : IPersonRepository
    {
        private readonly List<Person> _persons;
        private readonly List<Address> _addresses;
        private readonly List<Interest> _interests;
        private readonly List<PersonInterest> _personinterests;

        public PersonRepositoryFake()
        {
            _interests = new List<Interest>()
            {
                new Interest
                {
                    InterestId = 1,
                    Title = "Books"
                },
                new Interest
                {
                    InterestId = 2,
                    Title = "Writing"
                },
                new Interest
                {
                    InterestId = 3,
                    Title = "Movies"
                },
                new Interest
                {
                    InterestId = 4,
                    Title = "Sports"
                },
                new Interest
                {
                    InterestId = 5,
                    Title = "Hiking"
                }
            };

            _addresses = new List<Address>()
            {
                new Address
                {
                    Id = 1,
                    Address1 = "1000 Wayne Manor Dr.",
                    City = "Gotham",
                    State = "NJ",
                    ZipCode = 22222
                },
                new Address
                {
                    Id = 2,
                    Address1 = "404 7th St.",
                    Address2 = "Apt. 603",
                    City = "National City",
                    State = "WA",
                    ZipCode = 54545
                }
            };

            _personinterests = new List<PersonInterest>()
            {
                new PersonInterest
                {
                    PersonId = 1,
                    InterestId = 1,
                    Interest = _interests
                    .Where(x => x.InterestId == 1)
                    .FirstOrDefault()
                },
                new PersonInterest
                {
                    PersonId = 1,
                    InterestId = 4,
                    Interest = _interests
                    .Where(x => x.InterestId == 4)
                    .FirstOrDefault()
                },
                new PersonInterest
                {
                    PersonId = 2,
                    InterestId = 2,
                    Interest = _interests
                    .Where(x => x.InterestId == 2)
                    .FirstOrDefault()
                },
                new PersonInterest
                {
                    PersonId = 2,
                    InterestId = 3,
                    Interest = _interests
                    .Where(x => x.InterestId == 3)
                    .FirstOrDefault()
                }
            };

            _persons = new List<Person>()
            {
                new Person()
                {
                    PersonId = 1,
                    FirstName = "Bruce",
                    LastName = "Wayne",
                    Age = 37,
                    Address = _addresses
                    .Where(x => x.Id == 1)
                    .FirstOrDefault(),
                    ImageUrl = "~/images/bwayne.jpg",
                    PersonInterests = _personinterests
                    .Where(x => x.PersonId == 1)
                    .ToList()
                },
                new Person
                {
                    PersonId = 2,
                    FirstName = "Kara",
                    LastName = "Danvers",
                    Age = 22,
                    Address = _addresses.Where(x => x.Id == 2).FirstOrDefault(),
                    ImageUrl = "~/images/kdanvers.jpg",
                    PersonInterests = _personinterests
                    .Where(x => x.PersonId == 2)
                    .ToList()
                }
            };
        }

        public Person Get(int id)
        {
            return _persons
                .Where(x => x.PersonId == id)
                .FirstOrDefault();
        }

        public List<Interest> GetInterests(int id)
        {
            return _persons
                .Where(p => p.PersonId == id)
                .SelectMany(p => p.PersonInterests)
                .Select(pc => pc.Interest)
                .ToList();
        }

        public List<string> GetInterests()
        {
            return _interests.Select(x => x.Title).ToList();
        }

        public Address GetAddress(int id)
        {
            return _addresses
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public List<Person> GetAll()
        {
            return _persons;
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
            _addresses.Add(newAddress);

            newPerson.AddressId = newAddress.Id;


            foreach(var item in person.Interests)
            {
                _personinterests.Add(new PersonInterest()
                {
                    PersonId = newPerson.PersonId,
                    InterestId = _interests
                    .Where(x => x.Title == item)
                    .FirstOrDefault().InterestId,
                    Interest = _interests
                    .Where(x => x.Title == item)
                    .FirstOrDefault()
                });
            }
            
            if(person != null && !string.IsNullOrEmpty(person.FirstName) && !string.IsNullOrEmpty(person.LastName))
            {
                _persons.Add(newPerson);

                return newPerson;
            }

            return null;
        }
    }
}
