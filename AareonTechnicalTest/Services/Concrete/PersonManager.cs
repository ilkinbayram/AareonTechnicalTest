using AareonTechnicalTest.DataAccess.Abstract;
using AareonTechnicalTest.Models;
using AareonTechnicalTest.Models.Resources.Enum;
using AareonTechnicalTest.Models.Resources.Result;
using AareonTechnicalTest.Services.Abstract;
using IdentityServer4.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Web.Helpers;

namespace AareonTechnicalTest.Services.Concrete
{
    public class PersonManager : IPersonService
    {
        private readonly IPersonDal _personDal;
        private readonly ITrackLogService _trackLogService;
        public PersonManager(IPersonDal personDal, ITrackLogService trackLogService)
        {
            _personDal = personDal;
            _trackLogService = trackLogService;
        }

        public Result Add(Person entity, Person processHolder)
        {
            Result result;
            try
            {
                _personDal.Add(entity);
                result = Result.Success();

                var trackLog = new TrackLog(processHolder)
                {
                    ActionType = ActionTypes.Insert,
                    EntityId = 0,
                    EditedContent = JsonConvert.SerializeObject(entity, Formatting.Indented),
                    ProductType = ProductTypes.Person
                };

                _trackLogService.Add(trackLog);
            }
            catch (Exception ex)
            {
                result = Result.Failure(ex);
            }

            return result;
        }

        public Result Delete(Person entity, Person processHolder)
        {
            Result result;
            try
            {
                _personDal.Delete(entity);
                result = Result.Success();

                var trackLog = new TrackLog(processHolder)
                {
                    ActionType = ActionTypes.Delete,
                    EntityId = entity.Id,
                    EditedContent = JsonConvert.SerializeObject(entity, Formatting.Indented),
                    ProductType = ProductTypes.Person
                };

                _trackLogService.Add(trackLog);
            }
            catch (Exception ex)
            {
                result = Result.Failure(ex);
            }

            return result;
        }

        public Result<Person> Get(Expression<Func<Person, bool>> expression, Person processHolder)
        {
            Result<Person> result;
            try
            {
                var response = _personDal.Get(expression);
                result = Result<Person>.Success(response);
            }
            catch (Exception ex)
            {
                result = Result<Person>.Failure(ex);
            }

            return result;
        }

        public Result<List<Person>> GetAll(Person processHolder, Expression<Func<Person, bool>> expression = null)
        {
            Result<List<Person>> result;
            try
            {
                var response = _personDal.GetAll(expression);
                result = Result<List<Person>>.Success(response);
            }
            catch (Exception ex)
            {
                result = Result<List<Person>>.Failure(ex);
            }

            return result;
        }

        public Result<Person> GetUserForLogin(string username, string password)
        {
            Result<Person> result;
            try
            {
                var response = _personDal.Get(x => x.Username == username);
                if (!Crypto.VerifyHashedPassword(response.PasswordHash, password))
                    throw new Exception("Username or password is wrong!");
                result = Result<Person>.Success(response);
            }
            catch (Exception ex)
            {
                result = Result<Person>.Failure(ex);
            }

            return result;
        }

        public Result<Person> RegisterUser(Person person)
        {
            Result<Person> result;
            try
            {
                _personDal.Add(person);
                var registeredUser = _personDal.Get(x => x.Username == person.Username && 
                                                    x.Forename == person.Forename &&
                                                    x.Surname == person.Surname);
                result = Result<Person>.Success(registeredUser);

                var trackLog = new TrackLog()
                {
                    ActionType = ActionTypes.Registered,
                    EntityId = 0,
                    EditedContent = JsonConvert.SerializeObject(person, Formatting.Indented),
                    ProductType = ProductTypes.Person
                };

                _trackLogService.Add(trackLog);
            }
            catch (Exception ex)
            {
                result = Result<Person>.Failure(ex);
            }

            return result;
        }

        public Result Update(Person entity, Person processHolder)
        {
            Result result;
            try
            {
                _personDal.Update(entity);
                result = Result.Success();

                var trackLog = new TrackLog(processHolder)
                {
                    ActionType = ActionTypes.Update,
                    EntityId = entity.Id,
                    EditedContent = JsonConvert.SerializeObject(entity, Formatting.Indented),
                    ProductType = ProductTypes.Person
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
