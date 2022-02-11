using AareonTechnicalTest.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AareonTechnicalTest.DataAccess.Abstract
{
    public interface ITicketDal
    {
        void Add(Ticket entity);
        void Update(Ticket entity);
        void Delete(Ticket entity);
        Ticket Get(Expression<Func<Ticket, bool>> expression);
        List<Ticket> GetAll(Expression<Func<Ticket, bool>> expression = null);
    }
}
