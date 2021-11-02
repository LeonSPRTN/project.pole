using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project.pole.Models
{
    [Table("customer")]
    public class Customer : BaseModel
    {
        [Column("name")]
        [Display(Name = "Наименование организации")]
        [Required]
        public string Name{ get; set; }
        
        [Column("region")]
        [Display(Name = "Регион")]
        public string Region { get; set; }
        
        [Column("area")]
        [Display(Name = "Район")]
        public string Area{ get; set; }
        
        [Column("city")]
        [Display(Name = "Город")]
        public string City{ get; set; }

        [Column("settlement")]
        [Display(Name = "Населенный пункт")]
        public string Settlement{ get; set; }
        
        [Column("street")]
        [Display(Name = "Улица")]
        public string Street{ get; set; }
        
        [Column("house")]
        [Display(Name = "Дом")]
        public string House{ get; set; }

        [Column("Flat")]
        [Display(Name = "Офис")]
        public string Flat{ get; set; }

        public List<ObjectWork> ObjectWorks { get; set; }
    }
}