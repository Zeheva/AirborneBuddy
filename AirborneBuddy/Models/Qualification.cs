using System;
using System.ComponentModel.DataAnnotations;

namespace AirborneBuddy.Models
{
    public class Qualification
    {
        public int ID { get; set; }
        public virtual QalificationStatus? QalificationStatus { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfQualDateTime { get; set; }
    }

    public enum QalificationStatus
    {
        Parachutist, 
        SeniorParachutist,
        JumpMaster

    }
}