﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernDataServices.App.Models.Resources
{
    public class EmailResource
    {
        public int Id { get; set; }
        public string Address { get; set; }

        public List<Link> Links { get; set; }
    }
}
