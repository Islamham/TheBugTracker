using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TheBugTracker.Models
{
    public class Notification
    {
        //Primary Key
        public int Id { get; set; }

        [DisplayName("Ticket")]
        public int TicketId { get; set; }

        [Required]
        [DisplayName("Title")]
        public string Title { get; set; }

        [Required]
        [DisplayName("Message")]
        public string Message { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Date")]
        public DateTimeOffset Created { get; set; }

        [Required]
        [DisplayName("Recipient")]
        public string RecipientId { get; set; }

        [Required]
        [DisplayName("Sender")]
        public string SenderId { get; set; }

        [DisplayName("Has been viewed")]
        public bool Viewed { get; set; }


        //Navigation Properties
        public virtual Ticket Ticket { get; set; } //obtained by TicketId
        public virtual BTUser Recipient { get; set; } //obtained by RecipientId
        public virtual BTUser Sender { get; set; } //obtained by SenderId
    }
}
