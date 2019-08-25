using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeopleSearch.Models;
using PeopleSearch.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeopleSearch.Tests
{
    [TestClass]
    public class PersonRepositoryTests
    {
        PersonRepositoryFake _repository;

        public PersonRepositoryTests()
        {
            _repository = new PersonRepositoryFake();
        }

        [TestMethod]
        public void Get_ReturnsNameAgeImageUrl()
        {
            Person personTest = _repository.Get(1);
            Person person = new Person();
            person.PersonId = 1;
            person.FirstName = "Bruce";
            person.LastName = "Wayne";
            person.Age = 37;
            person.ImageUrl = "~/images/bwayne.jpg";

            Assert.AreEqual(person.FirstName, personTest.FirstName);
            Assert.AreEqual(person.LastName, personTest.LastName);
            Assert.AreEqual(person.Age, personTest.Age);
            Assert.AreEqual(person.ImageUrl, personTest.ImageUrl); ;
        }

        [TestMethod]
        public void Get_ReturnsInterests()
        {
            List<PersonInterest> interests = _repository.GetInterests(1);
            var originalInterests = new List<string>();

            foreach (var item in interests)
            {
                originalInterests.Add(item.Interest.Title);
            }

            Assert.AreEqual(originalInterests.Contains("Books"), true);
            Assert.AreEqual(originalInterests.Contains("Sports"), true);
        }

        [TestMethod]
        public void Get_ReturnsAddress()
        {
            Person personTest = _repository.Get(1);
            var originalAddress = personTest.Address;
            var testAddress = new Address
            {
                Id = 1,
                Address1 = "1000 Wayne Manor Dr.",
                City = "Gotham",
                State = "NJ",
                ZipCode = 22222
            };

            Assert.AreEqual(originalAddress.Address1, testAddress.Address1);
            Assert.AreEqual(originalAddress.Address2, testAddress.Address2);
            Assert.AreEqual(originalAddress.City, testAddress.City);
            Assert.AreEqual(originalAddress.State, testAddress.State);
            Assert.AreEqual(originalAddress.ZipCode, testAddress.ZipCode);
        }

        [TestMethod]
        public void Get_InvalidId_ReturnsNull()
        {
            Assert.AreEqual(_repository.Get(7), null);
        }

        [TestMethod]
        public void GetAll_ReturnsAll()
        {
            var persons = _repository.GetAll();

            Assert.AreEqual(persons.Count, 2);
        }

        [TestMethod]
        public void Add_CreatesNewPerson()
        {
            var person = new Person
            {
                PersonId = 3,
                FirstName = "Diana",
                LastName = "Prince",
                Age = 54,
                AddressId = 3,
                ImageUrl = "~/images/dprince.jpg"
            };

            var address = new Address
            {
                Id = 3,
                Address1 = "1200 Main Ave.",
                Address2 = "Suite 300",
                City = "New York City",
                State = "NY",
                ZipCode = 72172
            };

            var interests = new List<Interest>() {
                new Interest() { InterestId = 2 },
                new Interest() { InterestId = 3 }
            };

            _repository.Add(person, address, interests);
            var persons = _repository.GetAll();

            Assert.AreEqual(persons.Count, 3);
        }

        [TestMethod]
        public void Add_InvalidValues_DoesNotCreateNewPerson()
        {
            var person = new Person
            {
                PersonId = 4,
                Age = 27,
                AddressId = 4,
                ImageUrl = "~/images/bgordon.jpg"
            };

            var address = new Address
            {
                Id = 4,
                Address2 = "Suite 300",
                City = "New York City",
                State = "NY",
                ZipCode = 72172
            };

            var interests = new List<Interest>() {
                new Interest() { InterestId = 2 },
                new Interest() { InterestId = 3 }
            };

            var newPerson = _repository.Add(person, address, interests);
            var persons = _repository.GetAll();

            Assert.AreEqual(newPerson, null);
            Assert.AreEqual(persons.Count, 2);
        }
    }
}
