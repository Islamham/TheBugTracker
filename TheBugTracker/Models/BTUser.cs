using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheBugTracker.Models
{
    public class BTUser: IdentityUser
    {
        //creating public properties of the class

        [Required] //The following items are necessary to write a new record to DB (Cannot be NULL)
        [Display(Name = "First Name")] // For FE view (e.g., as label) to be more readable for End User
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [NotMapped] //Do not create a field in DB user table for "Fullname"
        [Display(Name = "Full Name")]
        public string FullName { get { return $"{FirstName} {LastName}"; } } //No need to set
    }
}
