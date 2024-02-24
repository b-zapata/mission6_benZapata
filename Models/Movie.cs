using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mission6_benZapata.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public string Title { get; set; }

        public string Year { get; set; }

        public string? Director { get; set; }

        public string? Rating { get; set; }

        public bool Edited { get; set; }

        public string? LentTo { get; set; }

        public string CopiedToPlex { get; set; }

        public string? Notes { get; set; }

    }
}
