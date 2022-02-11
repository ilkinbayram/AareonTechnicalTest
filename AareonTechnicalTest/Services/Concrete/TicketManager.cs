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
    public class TicketManager : ITicketService
    {
        private readonly ITicketDal _ticketDal;
        private readonly ITrackLogService _trackLogService;
        public TicketManager(ITicketDal ticketDal, ITrackLogService trackLogService)
        {
            _ticketDal = ticketDal;
            _trackLogService = trackLogService;
        }

        public Result Add(Ticket entity, Person processHolder)
        {
            Result result;
            try
            {
                entity.CreatedBy = string.Format("{0} {1}", processHolder.Forename, processHolder.Surname);
                entity.ModifiedBy = string.Format("{0} {1}", processHolder.Forename, processHolder.Surname);
                entity.CreatedDate = DateTime.Now;

                _ticketDal.Add(entity);
                result = Result.Success();

                var trackLog = new TrackLog(processHolder)
                {
                    ActionType = ActionTypes.Insert,
                    EntityId = 0,
                    EditedContent = JsonConvert.SerializeObject(entity, Formatting.Indented),
                    ProductType = ProductTypes.Ticket
                };

                _trackLogService.Add(trackLog);
            }
            catch (Exception ex)
            {
                result = Result.Failure(ex);
            }

            return result;
        }

        public Result Delete(Ticket entity, Person processHolder)
        {
            Result result;
            try
            {
                entity.ModifiedBy = string.Format("{0} {1}", processHolder.Forename, processHolder.Surname);
                _ticketDal.Delete(entity);
                result = Result.Success();

                var trackLog = new TrackLog(processHolder)
                {
                    ActionType = ActionTypes.Delete,
                    EntityId = entity.Id,
                    EditedContent = JsonConvert.SerializeObject(entity, Formatting.Indented),
                    ProductType = ProductTypes.Ticket
                };

                _trackLogService.Add(trackLog);
            }
            catch (Exception ex)
            {
                result = Result.Failure(ex);
            }

            return result;
        }

        public Result<Ticket> Get(Expression<Func<Ticket, bool>> expression, Person processHolder)
        {
            Result<Ticket> result;
            try
            {
                var response = _ticketDal.Get(expression);
                result = Result<Ticket>.Success(response);
            }
            catch (Exception ex)
            {
                result = Result<Ticket>.Failure(ex);
            }

            return result;
        }

        public Result<List<Ticket>> GetAll(Person processHolder, Expression<Func<Ticket, bool>> expression = null)
        {
            Result<List<Ticket>> result;
            try
            {
                var response = _ticketDal.GetAll(expression);
                result = Result<List<Ticket>>.Success(response);
            }
            catch (Exception ex)
            {
                result = Result<List<Ticket>>.Failure(ex);
            }

            return result;
        }

        public Result Update(Ticket entity, Person processHolder)
        {
            Result result;
            try
            {
                entity.ModifiedBy = string.Format("{0} {1}", processHolder.Forename, processHolder.Surname);
                _ticketDal.Update(entity);
                result = Result.Success();

                var trackLog = new TrackLog(processHolder)
                {
                    ActionType = ActionTypes.Update,
                    EntityId = entity.Id,
                    EditedContent = JsonConvert.SerializeObject(entity, Formatting.Indented),
                    ProductType = ProductTypes.Ticket
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
