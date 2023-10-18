using Humanizer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace TheBugTracker.Models
{
    public class Ticket
    {
        //Primary Key
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Title")]
        public string Title { get; set; }

        [Required]
        [DisplayName("Description")]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Created")]
        public DateTimeOffset Created { get; set; }

        [DataType(DataType.Date)]   
        public DateTimeOffset? Updated { get; set; } //? Implies NULL value valid

        [DisplayName("Archived")]
        public bool Archived { get; set; }

        [DisplayName("Archived")]
        public int ProjectId { get; set; }


        //Lookup Tables

        [DisplayName("Ticket Type")]
        public int TicketTypeId { get; set; }

        [DisplayName("Ticket Priority")]
        public int TicketPriorityId { get; set; }

        [DisplayName("Ticket Status")]
        public int TicketStatusId { get; set; }


        //BTUsers

        [DisplayName("Ticket Owner")]
        public string OwnerUserId { get; set; }

        [DisplayName("Ticket Developer")]
        public string DeveloperUserId { get; set; }


        //Navigation Properties
        //Virtual enables Lazy Loading (opposite of Eager Loading)
        //This version of .NET doesn't require it, but kept for visibility 
        public virtual Project Project { get; set; } //obtained by ProjectId

        public virtual TicketType TicketType { get; set; } //obtained by TicketTypeId

        public virtual TicketPriority TicketPriority { get; set; } //obtained by TicketPriorityId

        public virtual TicketStatus TicketStatus { get; set; } //obtained by TicketStatusId

        public virtual BTUser OwnerUser { get; set; } //obtained by OwnerUserId

        public virtual BTUser DeveloperUser { get; set; } //obtained by DeveloperUserId

        public virtual ICollection<TicketComment> Comments { get; set; } = new HashSet<TicketComment>();

        public virtual ICollection<TicketAttachment> Attachments { get; set; } = new HashSet<TicketAttachment>();

        public virtual ICollection<Notification> Notifications { get; set; } = new HashSet<Notification>();

        public virtual ICollection<TicketHistory> History { get; set; } = new HashSet<TicketHistory>();
    }
}
