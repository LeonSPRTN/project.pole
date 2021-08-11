using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project.pole.Models
{
    [Table("object")]
    public class Object : BaseModel
    {
        [Column("name")]
        [Display(Name = "Наименование организации")]
        public string Name{ get; set; }
        
        [Column("region")]
        [Display(Name = "Область")]
        public string Region { get; set; }
        
        [Column("district")]
        [Display(Name = "Регион/Район")]
        public string District{ get; set; }
        
        [Column("city")]
        [Display(Name = "Город/Населенный пункт")]
        public string City{ get; set; }
        
        [Column("street")]
        [Display(Name = "Улица")]
        public string Street{ get; set; }
        
        [Column("building")]
        [Display(Name = "Дом")]
        public string Building{ get; set; }
    }
}