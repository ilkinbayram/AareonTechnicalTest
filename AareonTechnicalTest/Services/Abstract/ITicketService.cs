using AareonTechnicalTest.Models;
using AareonTechnicalTest.Models.Resources.Result;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AareonTechnicalTest.Services.Abstract
{
    public interface ITicketService
    {
        Result<Ticket> Get(Expression<Func<Ticket, bool>> expression, Person person);
        Result<List<Ticket>> GetAll(Person person, Expression<Func<Ticket, bool>> expression = null);
        Result Update(Ticket entity, Person person);
        Result Delete(Ticket entity, Person person);
        Result Add(Ticket entity, Person person);
    }
}
