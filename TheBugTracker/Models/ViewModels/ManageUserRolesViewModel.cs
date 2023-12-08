﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace TheBugTracker.Models.ViewModels
{
    public class ManageUserRolesViewModel
    {
        public BTUser BTuser { get; set; }

        public MultiSelectList Roles { get; set; }

        public List<string> SelectedRoles { get; set; }

    }
}
