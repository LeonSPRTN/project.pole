using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project.pole.Models
{
    [Table("setting_estimate")]
    public class SettingEstimate: BaseModel
    {
        [Column("budget_coefficient")]
        [Display(Name = "Бюджетный коэффициент")]
        public double BudgetCoefficient { get; set; }

        [Column("inteco_coefficient")]
        [Display(Name = "Коэффициент ИНТЕКО")]
        public double IntecoCoefficient { get; set; }

        [Column("inflation_rate")]
        [Display(Name = "Коэффициент инфляции")]
        public double InflationRate { get; set; }

        [Column("nds")]
        [Display(Name = "НДС")]
        public double Nds { get; set; }
    }
}