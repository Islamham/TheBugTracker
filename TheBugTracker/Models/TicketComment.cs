using System;
using System.ComponentModel;

namespace TheBugTracker.Models
{
    public class TicketComment
    {
        //Primary Key
        public int Id { get; set; }

        [DisplayName("Member Comment")]
        public string Comment { get; set; }

        [DisplayName("Date")]
        public DateTimeOffset Created { get; set; }

        [DisplayName("Ticket")]
        public int TicketId { get; set; } //Foreign key: reference to primary key in the ticket table

        [DisplayName("Team Member")]
        public string UserId { get; set; } //Foreign key: reference to primary key in user table 


        //Navigation Properties
        public virtual Ticket Ticket { get; set; } //will be obtained by TicketId

        public virtual BTUser User { get; set; } //will be obtained by UserId
    }
}
