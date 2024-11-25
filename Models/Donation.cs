using System;
using System.Collections.Generic;

namespace Db_FirstPet.Models
{
    public partial class Donation
    {
        public int DonationId { get; set; }
        public string? DonorName { get; set; }
        public string? DonationType { get; set; }
        public decimal? DonationAmount { get; set; }
        public string? DonationItem { get; set; }
        public DateTime? DonationDate { get; set; }
        public int? ShelterId { get; set; }

        public virtual Shelter? Shelter { get; set; }
    }
}
