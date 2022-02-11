using AareonTechnicalTest.DataAccess.Abstract;
using AareonTechnicalTest.DataAccess.Concrete.EntityFramework;
using AareonTechnicalTest.Services.Abstract;
using AareonTechnicalTest.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AareonTechnicalTest.Resolver
{
    public static class DependencyResolver
    {
        public static void Inject(this IServiceCollection collection)
        {
            #region Note
            collection.AddScoped<INoteDal, EfNoteDal>();
            collection.AddScoped<INoteService, NoteManager>();
            #endregion

            #region Person
            collection.AddScoped<IPersonDal, EfPersonDal>();
            collection.AddScoped<IPersonService, PersonManager>();
            #endregion

            #region Ticket
            collection.AddScoped<ITicketDal, EfTicketDal>();
            collection.AddScoped<ITicketService, TicketManager>();
            #endregion

            #region TrackLog
            collection.AddScoped<ITrackLogDal, EfTrackLogDal>();
            collection.AddScoped<ITrackLogService, TrackLogManager>();
            #endregion
        }
    }
}
