using AareonTechnicalTest.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AareonTechnicalTest.DataAccess.Abstract
{
    public interface IPersonDal
    {
        void Add(Person entity);
        void Update(Person entity);
        void Delete(Person entity);
        Person Get(Expression<Func<Person, bool>> expression);
        List<Person> GetAll(Expression<Func<Person, bool>> expression = null);
    }
}
