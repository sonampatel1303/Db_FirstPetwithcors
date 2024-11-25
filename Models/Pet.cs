using System;
using System.Collections.Generic;

namespace Db_FirstPet.Models
{
    public partial class Pet
    {
        public int PetId { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Breed { get; set; }
        public string? Type { get; set; }
        public bool? AvailableForAdoption { get; set; }
        public int? OwnerId { get; set; }
        public int? ShelterId { get; set; }

        public virtual Participant? Owner { get; set; }
        public virtual Shelter? Shelter { get; set; }
    }
}
