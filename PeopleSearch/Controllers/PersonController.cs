using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeopleSearch.Models;
using PeopleSearch.Repositories;

namespace PeopleSearch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _repository;

        public PersonController(IPersonRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Person?query=
        [HttpGet]
        public List<PersonViewModel> Get(string query)
        {
            List<PersonViewModel> persons = PopulatePersonViewModels(_repository.GetAll());

            if (!string.IsNullOrEmpty(query))
            {
                persons = persons.Where(x => x.FirstName.ToLower().Contains(query.ToLower()) || x.LastName.ToLower().Contains(query.ToLower())).ToList();
            }
            
            return persons;
        }

        public List<PersonViewModel> PopulatePersonViewModels(ICollection<Person> persons)
        {
            var model = new List<PersonViewModel>();
            foreach(var person in persons)
            {
                var personVM = new PersonViewModel();

                personVM.FirstName = person.FirstName;
                personVM.LastName = person.LastName;
                personVM.Age = person.Age;
                personVM.ImageUrl = person.ImageUrl;

                Address address = _repository.GetAddress(person.PersonId);
                personVM.Address1 = address.Address1;
                personVM.Address2 = address.Address2;
                personVM.City = address.City;
                personVM.State = address.State;
                personVM.ZipCode = address.ZipCode;

                List<Interest> interests = _repository.GetInterests(person.PersonId);

                if (interests.Any())
                {
                    foreach (var item in interests)
                    {
                        if (item?.Title != null)
                        {
                            personVM.Interests.Add(item?.Title);
                        }                    
                    }
                }

                model.Add(personVM);
            }

            return model;
        }
    }
}
