using AareonTechnicalTest.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AareonTechnicalTest.DataAccess.Abstract
{
    public interface ITrackLogDal
    {
        void Add(TrackLog entity);
        void Update(TrackLog entity);
        void Delete(TrackLog entity);
        TrackLog Get(Expression<Func<TrackLog, bool>> expression);
        List<TrackLog> GetAll(Expression<Func<TrackLog, bool>> expression = null);
    }
}
