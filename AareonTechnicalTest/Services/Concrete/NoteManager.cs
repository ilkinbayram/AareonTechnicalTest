using AareonTechnicalTest.DataAccess.Abstract;
using AareonTechnicalTest.Models;
using AareonTechnicalTest.Models.Resources.Enum;
using AareonTechnicalTest.Models.Resources.Result;
using AareonTechnicalTest.Services.Abstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AareonTechnicalTest.Services.Concrete
{
    public class NoteManager : INoteService
    {
        private readonly INoteDal _noteDal;
        private readonly ITrackLogService _trackLogService;
        public NoteManager(INoteDal noteDal, ITrackLogService trackLogService)
        {
            _noteDal = noteDal;
            _trackLogService = trackLogService;
        }

        public Result Add(Note entity, Person person)
        {
            Result result;
            try
            {
                entity.CreatedBy = string.Format("{0} {1}", person.Forename, person.Surname);
                entity.ModifiedBy = string.Format("{0} {1}", person.Forename, person.Surname);
                entity.CreatedDate = DateTime.Now;

                _noteDal.Add(entity);
                result = Result.Success();

                var trackLog = new TrackLog(person)
                {
                    ActionType = ActionTypes.Insert,
                    EntityId = 0,
                    EditedContent = JsonConvert.SerializeObject(entity, Formatting.Indented),
                    ProductType = ProductTypes.Note
                };

                _trackLogService.Add(trackLog);
            }
            catch(Exception ex)
            {
                result = Result.Failure(ex);
            }

            return result;
        }

        public Result Delete(Note entity, Person person)
        {
            Result result;
            try
            {
                entity.ModifiedBy = string.Format("{0} {1}", person.Forename, person.Surname);
                _noteDal.Delete(entity);
                result = Result.Success();

                var trackLog = new TrackLog(person)
                {
                    ActionType = ActionTypes.Delete,
                    EntityId = entity.Id,
                    EditedContent = JsonConvert.SerializeObject(entity, Formatting.Indented),
                    ProductType = ProductTypes.Note
                };

                _trackLogService.Add(trackLog);
            }
            catch (Exception ex)
            {
                result = Result.Failure(ex);
            }

            return result;
        }

        public Result<Note> Get(Expression<Func<Note, bool>> expression, Person person)
        {
            Result<Note> result;
            try
            {
                var response = _noteDal.Get(expression);
                result = Result<Note>.Success(response);
            }
            catch (Exception ex)
            {
                result = Result<Note>.Failure(ex);
            }

            return result;
        }

        public Result<List<Note>> GetAll(Person person, Expression<Func<Note, bool>> expression = null)
        {
            Result<List<Note>> result;
            try
            {
                var response = _noteDal.GetAll(expression);
                result = Result<List<Note>>.Success(response);
            }
            catch (Exception ex)
            {
                result = Result<List<Note>>.Failure(ex);
            }

            return result;
        }

        public Result Update(Note entity, Person person)
        {
            Result result;
            try
            {
                entity.ModifiedBy = string.Format("{0} {1}", person.Forename, person.Surname);
                _noteDal.Update(entity);
                result = Result.Success();

                var trackLog = new TrackLog(person)
                {
                    ActionType = ActionTypes.Update,
                    EntityId = entity.Id,
                    EditedContent = JsonConvert.SerializeObject(entity, Formatting.Indented),
                    ProductType = ProductTypes.Note
                };

                _trackLogService.Add(trackLog);
            }
            catch (Exception ex)
            {
                result = Result.Failure(ex);
            }

            return result;
        }
    }
}
