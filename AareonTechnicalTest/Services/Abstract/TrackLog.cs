using AareonTechnicalTest.Models;
using AareonTechnicalTest.Models.Resources.Result;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AareonTechnicalTest.Services.Abstract
{
    public interface ITrackLogService
    {
        Result<TrackLog> Get(Expression<Func<TrackLog, bool>> expression);
        Result<List<TrackLog>> GetAll(Expression<Func<TrackLog, bool>> expression = null);
        Result Update(TrackLog entity);
        Result Delete(TrackLog entity);
        Result Add(TrackLog entity);
    }
}
