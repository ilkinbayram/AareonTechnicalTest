using AareonTechnicalTest.Models.BaseModels;
using System.Collections.Generic;

namespace AareonTechnicalTest.Models
{
    public class Ticket : BaseEntity
    {
        public string Content { get; set; }

        public int PersonId { get; set; }

        public virtual List<Note> Notes { get; set; }
    }
}
