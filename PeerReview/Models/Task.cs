using System;
using System.ComponentModel.DataAnnotations;

namespace PeerReview.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Descrition { get; set; }
        private DateTime _expirationDate;
        [DataType(DataType.DateTime)]
        public DateTime ExpirationDate
        {
            get => _expirationDate;
            set => _expirationDate = value;
        }
    }
}