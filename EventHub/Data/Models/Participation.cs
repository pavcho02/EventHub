﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    internal class Participation
    {
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public string EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}
