using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;


namespace TheBugTracker.Models
{
    public class TicketAttachment
    {
        //Primary Key
        public int Id { get; set; }

        [DisplayName("Ticket")]
        public int TicketId { get; set; } //Foreign key: reference to primary key in the ticket table

        [DisplayName("File Date")]
        public DateTimeOffset Created { get; set; } //timestamp of creation of attachment

        [DisplayName("Team Member")]
        public string UserId { get; set; } //Foreign key: reference to primary key in user table 

        [DisplayName("File Description")]
        public string Description { get; set; }


        [NotMapped] //will not be copied to database
        [DataType(DataType.Upload)]
        public IFormFile FormFile { get; set; }

        [DisplayName("File Name")]
        public string FileName { get; set; }
        public byte[] FileData { get; set; }

        [DisplayName("File Extension")]
        public string FileContentType { get; set; }


        //Navigation Properties
        public virtual Ticket Ticket { get; set; } //will be obtained by TicketId

        public virtual BTUser User { get; set; } //will be obtained by UserId
    }
}
