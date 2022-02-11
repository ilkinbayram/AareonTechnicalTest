using AareonTechnicalTest.DataAccess.Abstract;
using AareonTechnicalTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AareonTechnicalTest.DataAccess.Concrete.EntityFramework
{
    public class EfTicketDal : ITicketDal
    {
        private ApplicationContext _applicationContext;

        public EfTicketDal(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void Add(Ticket entity)
        {
            _applicationContext.Set<Ticket>().Add(entity);
            Commit();
        }

        public void Delete(Ticket entity)
        {
            _applicationContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            Commit();
        }

        public Ticket Get(Expression<Func<Ticket, bool>> expression)
        {
            return _applicationContext.Set<Ticket>().FirstOrDefault(expression);
        }

        public List<Ticket> GetAll(Expression<Func<Ticket, bool>> expression = null)
        {
            return expression == null
                ? _applicationContext.Set<Ticket>().ToList()
                : _applicationContext.Set<Ticket>().Where(expression).ToList();

        }

        public void Update(Ticket entity)
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
