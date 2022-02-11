using AareonTechnicalTest.Models.BaseModels;
using AareonTechnicalTest.Models.Resources.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AareonTechnicalTest.Models
{
    public class Note : BaseEntity
    {
        public string Content { get; set; }

        public int TickedId { get; set; }
    }
}
