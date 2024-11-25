﻿using System;
using System.Collections.Generic;

namespace Db_FirstPet.Models
{
    public partial class AdoptionEvent
    {
        public AdoptionEvent()
        {
            Participants = new HashSet<Participant>();
        }

        public int EventId { get; set; }
        public string? EventName { get; set; }
        public DateTime? EventDate { get; set; }
        public string? Location { get; set; }

        public virtual ICollection<Participant> Participants { get; set; }
    }
}
