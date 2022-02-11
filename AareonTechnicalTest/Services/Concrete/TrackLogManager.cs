using AareonTechnicalTest.DataAccess.Abstract;
using AareonTechnicalTest.Models;
using AareonTechnicalTest.Models.Resources.Result;
using AareonTechnicalTest.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AareonTechnicalTest.Services.Concrete
{
    public class TrackLogManager : ITrackLogService
    {
        private readonly ITrackLogDal _trackLogDal;
        public TrackLogManager(ITrackLogDal trackLogDal)
        {
            _trackLogDal = trackLogDal;
        }

        public Result Add(TrackLog entity)
        {
            Result result;
            try
            {
                _trackLogDal.Add(entity);
                result = Result.Success();
            }
            catch (Exception ex)
            {
                result = Result.Failure(ex);
            }

            return result;
        }

        public Result Delete(TrackLog entity)
        {
            Result result;
            try
            {
                _trackLogDal.Delete(entity);
                result = Result.Success();
            }
            catch (Exception ex)
            {
                result = Result.Failure(ex);
            }

            return result;
        }

        public Result<TrackLog> Get(Expression<Func<TrackLog, bool>> expression)
        {
            Result<TrackLog> result;
            try
            {
                var response = _trackLogDal.Get(expression);
                result = Result<TrackLog>.Success(response);
            }
            catch (Exception ex)
            {
                result = Result<TrackLog>.Failure(ex);
            }

            return result;
        }

        public Result<List<TrackLog>> GetAll(Expression<Func<TrackLog, bool>> expression = null)
        {
            Result<List<TrackLog>> result;
            try
            {
                var response = _trackLogDal.GetAll(expression);
                result = Result<List<TrackLog>>.Success(response);
            }
            catch (Exception ex)
            {
                result = Result<List<TrackLog>>.Failure(ex);
            }

            return result;
        }

        public Result Update(TrackLog entity)
        {
            Result result;
            try
            {
                _trackLogDal.Update(entity);
                result = Result.Success();
            }
            catch (Exception ex)
            {
                result = Result.Failure(ex);
            }

            return result;
        }
    }
}
