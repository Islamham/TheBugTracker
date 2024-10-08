﻿using System;
using System.ComponentModel;

namespace TheBugTracker.Models
{
    public class Invite
    {
        //Primary Key
        public int Id { get; set; }

        [DisplayName("Date Sent")]
        public DateTimeOffset InviteDate { get; set; }

        [DisplayName("Join Date")] //Timestamp for when user joins
        public DateTimeOffset JoinDate { get; set; }

        [DisplayName("Code")]
        public Guid CompanyToken { get; set; }

        [DisplayName("Company")]
        public int CompanyId { get; set; }

        [DisplayName("Project")]
        public int ProjectId { get; set; }

        [DisplayName("Invitor")]
        public string InvitorId { get; set; }

        [DisplayName("Invitee")]
        public string InviteeId { get; set; }

        [DisplayName("Invitee Email")]
        public string InviteeEmail { get; set; }
        
        [DisplayName("Invitee First Name")]
        public string InviteeFirstName { get; set; }

        [DisplayName("Invitee Last Name")]
        public string InviteeLastName { get; set; }

        public bool IsValid { get; set; }


        //Navigation Properties

        public virtual Company Company { get; set; } //obtained by CompanyId

        public virtual BTUser Invitor { get; set; } //obtained by InvitorId

        public virtual BTUser Invitee { get; set; } //obtained by InviteeId

        public virtual Project Project { get; set; } //obtained by ProjectId

    }
}
