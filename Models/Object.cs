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
        
        [Column("region")]
        [Display(Prompt = "Область")]
        public string Region { get; set; }
        
        [Column("district")]
        [Display(Prompt = "Регион/Район")]
        public string District{ get; set; }
        
        [Column("city")]
        [Display(Prompt = "Город/Населенный пункт")]
        public string City{ get; set; }
        
        [Column("street")]
        [Display(Prompt = "Улица")]
        public string Street{ get; set; }
        
        [Column("building")]
        [Display(Prompt = "Дом")]
        public string Building{ get; set; }
    }
}