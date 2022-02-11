using AareonTechnicalTest.DataAccess.Abstract;
using AareonTechnicalTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AareonTechnicalTest.DataAccess.Concrete.EntityFramework
{
    public class EfNoteDal : INoteDal
    {
        private ApplicationContext _applicationContext;

        public EfNoteDal(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void Add(Note entity)
        {
            _applicationContext.Set<Note>().Add(entity);
            Commit();
        }

        public void Delete(Note entity)
        {
            _applicationContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            Commit();
        }

        public Note Get(Expression<Func<Note, bool>> expression)
        {
            return _applicationContext.Set<Note>().FirstOrDefault(expression);
        }

        public List<Note> GetAll(Expression<Func<Note, bool>> expression = null)
        {
            return expression == null
                ? _applicationContext.Set<Note>().ToList()
                : _applicationContext.Set<Note>().Where(expression).ToList();

        }

        public void Update(Note entity)
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
