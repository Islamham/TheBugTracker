using System;
using System.ComponentModel;
using System.Net.Sockets;

namespace TheBugTracker.Models
{
    public class TicketHistory
    {
        public int Id { get; set; }

        [DisplayName("Ticket")]
        public int TicketId { get; set; } //Foreign key: reference to primary key in the ticket table

        [DisplayName("Updated Item")]
        public string Property { get; set; } //which property of the ticket was modified

        [DisplayName("Previous")] //previous value of modified value
        public string OldValue { get; set; }

        [DisplayName("Current")] //new value of modified value
        public string NewValue { get; set; }

        [DisplayName("Date Modified")]
        public DateTimeOffset Created { get; set; } //timestamp of creation of ticket history

        [DisplayName("Description of Change")]
        public string Description { get; set; }

        [DisplayName("Team Member")]
        public string UserId { get; set; } //Foreign key: reference to primary key in user table 


        //Navigation Properties
        public virtual Ticket Ticket { get; set; } //will be obtained by TicketId

        public virtual BTUser User { get; set; } //will be obtained by UserId

    }
}
