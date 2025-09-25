using System.ComponentModel.DataAnnotations;

namespace PF_LAB3.Models
{
    public class Card
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; } // Fixed NRT warning

        [Required]
        public required string Rarity { get; set; } // Fixed NRT warning

        [Required]
        public required string CharacterName { get; set; } // Fixed NRT warning

        [Required]
        public required string CharacterImageUrl { get; set; } // Fixed NRT warning

        [Required]
        public required string Type { get; set; } // Fixed NRT warning

        [Required]
        public required string Description { get; set; } // Fixed NRT warning
    }
}