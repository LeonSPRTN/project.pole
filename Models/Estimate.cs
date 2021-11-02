using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project.pole.Models
{
    [Table("estimate")]
    public class Estimate: BaseModel
    {
        private DateTime _dateCreated;

        [Column("path")]
        public string Path { get; set; }

        [Column("date_created")] 
        public DateTime DateCreated
        {
            get => _dateCreated;
            private set => _dateCreated = DateTime.Now;
        }

        public long ObjectWorkId { get; set; }
        [Column("object_work")]
        public ObjectWork ObjectWork { get; set; }

    }
}