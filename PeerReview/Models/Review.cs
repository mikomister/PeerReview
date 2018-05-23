using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Infrastructure;

namespace PeerReview.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [Range(1,10)]
        public int Assessment { get; set; }
        
        [Required]
        [MaxLength(512)]
        public string Opinion { get; set; }

        public int SubmissionId { get; set; }
        public Submission Submission { get; set; }
        
        public int AuthorId { get; set; }
        public User Author { get; set; }

    }
}