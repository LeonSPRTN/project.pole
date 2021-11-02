using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project.pole.Models
{
    [Table("object_work")]
    public class ObjectWork: BaseModel
    {
        [Column("city")]
        [Display(Name = "Город")]
        public string City{ get; set; }

        [Column("street")]
        [Display(Name = "Улица")]
        public string Street{ get; set; }

        [Column("house")]
        [Display(Name = "Дом")]
        public string House{ get; set; }

        [Column("body")]
        [Display(Name = "Корпус")]
        public string Body{ get; set; }

        [Column("plot_area")]
        [Display(Name = "Площадь участка(Га)")]
        public double PlotArea { get; set; }

        [Column("building_area")]
        [Display(Name = "Площадь зданий(кв.м)")]
        public double BuildingArea { get; set; }

        [Column("pit_depth")]
        [Display(Name = "Глубина котлована(м)")]
        public double PitDepth { get; set; }

        [Column("winter_coefficient")]
        [Display(Name = "Зимний коэффициент")]
        public double WinterCoefficient { get; set; }

        [Column("inteco")]
        [Display(Name = "Интеко")]
        public double Inteco { get; set; }

        [Column("budget")]
        [Display(Name = "Бюджетный")]
        public double Budget { get; set; }

        [Column("without_coefficient")]
        [Display(Name = "Без коэффициента")]
        public double WithoutCoefficient { get; set; }

        [Column("moscow_coefficient")]
        [Display(Name = "Московкий коэффициент")]
        public bool MoscowCoefficient { get; set; }

        [Column("without_radon")]
        [Display(Name = "Без родона")]
        public bool WithoutRadon { get; set; }

        [Column("track")]
        [Display(Name = "Трасса")]
        public bool Track { get; set; }

        [Column("customer_id")]
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }

        public Estimate Estimaet { get; set; }
    }
}