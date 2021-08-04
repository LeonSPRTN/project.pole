using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project.pole.Models
{
    [Table("object")]
    public class Object : BaseModel
    {
        [Column("name")]
        [Display(Prompt = "Наименование организации")]
        public string Name{ get; set; }
    }
}