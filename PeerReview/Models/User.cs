using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Query.Expressions;

namespace PeerReview.Models
{
    public class User : IdentityUser
    {
        public int CountInvites { get; set; }
        
        [NotMapped]
        private const double Balancer = 100000;
        
        public List<Submission> Submissions;
        public List<Review> Reviews;
        
        public double Rating()
        {
            var s = Submissions?.Count ?? 0;
            var r = Reviews?.Count ?? 0;
            return r-s + r/Balancer;
        }
    }
}