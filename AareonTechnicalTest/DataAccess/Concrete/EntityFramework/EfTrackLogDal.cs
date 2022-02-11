using AareonTechnicalTest.DataAccess.Abstract;
using AareonTechnicalTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AareonTechnicalTest.DataAccess.Concrete.EntityFramework
{
    public class EfTrackLogDal : ITrackLogDal
    {
        private ApplicationContext _applicationContext;

        public EfTrackLogDal(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void Add(TrackLog entity)
        {
            _applicationContext.Set<TrackLog>().Add(entity);
            Commit();
        }

        public void Delete(TrackLog entity)
        {
            _applicationContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            Commit();
        }

        public TrackLog Get(Expression<Func<TrackLog, bool>> expression)
        {
            return _applicationContext.Set<TrackLog>().FirstOrDefault(expression);
        }

        public List<TrackLog> GetAll(Expression<Func<TrackLog, bool>> expression = null)
        {
            return expression == null
                ? _applicationContext.Set<TrackLog>().ToList()
                : _applicationContext.Set<TrackLog>().Where(expression).ToList();

        }

        public void Update(TrackLog entity)
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
