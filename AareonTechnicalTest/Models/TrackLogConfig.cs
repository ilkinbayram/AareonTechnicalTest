using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AareonTechnicalTest.Models
{
    public static class TrackLogConfig
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrackLog>(
                entity =>
                {
                    entity.HasKey(e => e.Id);
                });
        }
    }
}
