using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project.pole.Models
{
    [Table("estimate")]
    public class Estimate
    {
        private DateTime _dateCreated;

        [Key]
        [ForeignKey("Customer")]
        public long Id { get; init; }

        [Column("path")]
        public string Path { get; set; }

        [Column("date_created")] 
        public DateTime DateCreated
        {
            get => _dateCreated;
            private set => _dateCreated = DateTime.Now;
        }


    }
}