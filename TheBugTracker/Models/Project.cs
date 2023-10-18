using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheBugTracker.Models
{
    public class Project
    {

        public int Id { get; set; }

        [DisplayName("Company Id")]
        public int? CompanyId { get; set; } //? implies nullable

        [Required]
        [StringLength(50)]
        [DisplayName("Project Name")]
        public string Name { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Start Date")]
        public DateTimeOffset StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("End Date")]
        public DateTimeOffset EndDate { get; set; }

        [DisplayName("Priority")]
        public int? ProjectPriorityId { get; set; }

        [DisplayName("Archived")]
        public bool Archived { get; set; }


        [NotMapped] //will not be copied to database
        [DataType(DataType.Upload)]
        public IFormFile ImageFormFile { get; set; }

        [DisplayName("File Name")]
        public string ImageFileName { get; set; }
        public byte[] ImageFileData { get; set; }

        [DisplayName("File Extension")]
        public string ImageContentType { get; set; }


        //Navigation Properties
        public virtual Company Company { get; set; }

        public virtual ProjectPriority ProjectPriority { get; set; } 
        
        public virtual ICollection<BTUser> Members { get; set; } = new HashSet<BTUser>();

        public virtual ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();


    }
}
