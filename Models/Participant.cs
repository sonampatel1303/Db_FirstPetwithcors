using System;
using System.Collections.Generic;

namespace Db_FirstPet.Models
{
    public partial class Participant
    {
        public Participant()
        {
            Pets = new HashSet<Pet>();
        }

        public int ParticipanntId { get; set; }
        public string? ParticipantName { get; set; }
        public string? ParticipantType { get; set; }
        public int? EventId { get; set; }

        public virtual AdoptionEvent? Event { get; set; }
        public virtual ICollection<Pet> Pets { get; set; }
    }
}
