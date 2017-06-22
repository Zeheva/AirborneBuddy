using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AirborneBuddy.Models
{
    public class Paratrooper
    {
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "Ensure first letter is Caplized and all letters only")]

        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string FirstName { get; set; }
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string LastName { get; set; }
        public string CurrentStatus { get; set; }   
        public int? OrganizationID { get; set; }
        public virtual Organization Organization { get; set; }
        public int? QualificationID { get; set; }
        public virtual Qualification Qualification { get; set; }

        public virtual ICollection<AirborneOperation> Jumps { get; set; }


    }
}