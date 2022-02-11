using AareonTechnicalTest.DataAccess.Abstract;
using AareonTechnicalTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AareonTechnicalTest.DataAccess.Concrete.EntityFramework
{
    public class EfPersonDal : IPersonDal
    {
        private ApplicationContext _applicationContext;

        public EfPersonDal(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void Add(Person entity)
        {
            _applicationContext.Set<Person>().Add(entity);
            Commit();
        }

        public void Delete(Person entity)
        {
            _applicationContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            Commit();
        }

        public Person Get(Expression<Func<Person, bool>> expression)
        {
            return _applicationContext.Set<Person>().FirstOrDefault(expression);
        }

        public List<Person> GetAll(Expression<Func<Person, bool>> expression = null)
        {
            return expression == null
                ? _applicationContext.Set<Person>().ToList()
                : _applicationContext.Set<Person>().Where(expression).ToList();

        }

        public void Update(Person entity)
        {
            _applicationContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Commit();
        }

        private void Commit()
        {
            _applicationContext.SaveChanges();
        }
    }
}
