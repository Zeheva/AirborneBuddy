using System;
using System.ComponentModel.DataAnnotations;

namespace AirborneBuddy.Models
{
    public class Jumps
    {
        public int ID { get; set; }
        public string DropZone { get; set; }
        public string AircraftPlatform { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateTime { get; set; }
        //better way to hold pay dates //break out?
        public string PayPeriodCovered { get; set; }
        public virtual JumpType? JumpType { get; set; }
        

    }
    public enum JumpType
    {//is there a way to split Mass Tactical in to two words and others based on enum rules
        Tactical, MassTactical,
        AdministrativeNonTatical,
        JumpMaster, CombatEquipment,
        Night, Combat
    }
}