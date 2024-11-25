using System;
using System.Collections.Generic;

namespace Db_FirstPet.Models
{
    public partial class Shelter
    {
        public Shelter()
        {
            Donations = new HashSet<Donation>();
            Pets = new HashSet<Pet>();
        }

        public int ShelterId { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }

        public virtual ICollection<Donation> Donations { get; set; }
        public virtual ICollection<Pet> Pets { get; set; }
    }
}
