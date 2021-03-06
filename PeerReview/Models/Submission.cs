﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PeerReview.Models
{
    public class Submission
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(4096)]
        public string Code { get; set; }

        public double AverageAssessment
        {
            get { return this.Reviews.Average(review => review.Assessment); }
        }
        
        public bool IsChecking { get; set; }
        
        public List<Review> Reviews { get; set; }
        
        public int AuthorId { get; set; }
        public User Author { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; }
        
    }
}