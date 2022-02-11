using AareonTechnicalTest.Models.BaseModels;
using AareonTechnicalTest.Models.Resources.Enum;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace AareonTechnicalTest.Models
{
    public class TrackLog
    {
        public TrackLog(Person person)
        {
            CreatedDate = DateTime.Now;
            ModifiedById = person.Id;
        }

        public TrackLog()
        {
            CreatedDate = DateTime.Now;

            // If ModifiedId equals to {0} it means that process completed by the System
            ModifiedById = 0;
        }

        [Key]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public ActionTypes ActionType { get; set; }
        public ProductTypes ProductType { get; set; }
        public int EntityId { get; set; }
        public int ModifiedById { get; set; }
        public string InitialContent { get; set; }
        public string EditedContent { get; set; }
    }
}
