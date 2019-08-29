using PeopleSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleSearch.Repositories
{
    public interface IPersonRepository
    {
        Person Get(int id);

        List<Interest> GetInterests(int id);

        List<string> GetInterests();

        Address GetAddress(int id);

        List<Person> GetAll();

        Person Add(PersonViewModel person);
    }
}
