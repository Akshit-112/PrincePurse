using System;
using System.ComponentModel.DataAnnotations;

namespace PrincePurse.Models
{
    public class Purse
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Brand { get; set; }

        public string Colour { get; set; }
        public string Materials { get; set; }

        [Range(1, 100)]
        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public string Style { get; set; }
        [Required]
        public string Availability { get; set; }
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5 ")]
        public double CustomerRating { get; set; }

    }
}