﻿using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace TheBugTracker.Models
{
    public class Company
    {
        //Primary Key
        public int Id { get; set; }

        [DisplayName("Company Name")]
        public string Name { get; set; }

        [DisplayName("Company Description")]
        public string Description { get; set; }


        //Navigation Properties
        public virtual ICollection<BTUser> Members { get; set; }

        public virtual ICollection<Project> Projects { get; set; }

        public virtual ICollection<Invite> Invites { get; set; }
    }
}
