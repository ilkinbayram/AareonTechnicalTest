using AareonTechnicalTest.Models;
using AareonTechnicalTest.Models.Resources.Result;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AareonTechnicalTest.Services.Abstract
{
    public interface INoteService
    {
        Result<Note> Get(Expression<Func<Note, bool>> expression, Person person);
        Result<List<Note>> GetAll(Person person, Expression<Func<Note, bool>> expression = null);
        Result Update(Note entity, Person person);
        Result Delete(Note entity, Person person);
        Result Add(Note entity, Person person);
    }
}
