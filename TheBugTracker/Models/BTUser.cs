using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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

        public int? CompanyId  { get; set; } //? allows nullable (User will temporarily not have a company)


        //Avatar
        [NotMapped] //will not be copied to database
        [DataType(DataType.Upload)]
        public IFormFile AvatarFormFile { get; set; }

        [DisplayName("Avatar")]
        public string AvatarFileName { get; set; }
        public byte[] AvatarFileData { get; set; }

        [DisplayName("File Extension")]
        public string AvatarContentType { get; set; }


        //Navigation Properties
        public virtual Company Company { get; set; } //obtained by CompanyId

        public virtual ICollection<Project> Projects { get; set; }


    }
}
