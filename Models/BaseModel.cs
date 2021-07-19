using System.ComponentModel.DataAnnotations.Schema;

namespace project.pole.Models
{
    public class BaseModel
    {
        [Column("id")]
        public long Id { get; private set; }
    }
}
