using AareonTechnicalTest.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AareonTechnicalTest.DataAccess.Abstract
{
    public interface INoteDal
    {
        void Add(Note entity);
        void Update(Note entity);
        void Delete(Note entity);
        Note Get(Expression<Func<Note, bool>> expression);
        List<Note> GetAll(Expression<Func<Note, bool>> expression = null);
    }
}
