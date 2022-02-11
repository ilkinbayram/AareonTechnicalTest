using AareonTechnicalTest.Models;
using AareonTechnicalTest.Models.Resources.Result;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AareonTechnicalTest.Services.Abstract
{
    public interface IPersonService
    {
        Result<Person> Get(Expression<Func<Person, bool>> expression, Person person);
        Result<List<Person>> GetAll(Person person, Expression<Func<Person, bool>> expression = null);
        Result Update(Person entity, Person person);
        Result Delete(Person entity, Person person);
        Result Add(Person entity, Person person);

        Result<Person> GetUserForLogin(string username, string password);
        Result<Person> RegisterUser(Person person);
    }
}
