using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project.pole.Models
{
    [Table("user")]
    public class User : BaseModel
    {
        [Column("login")]
        [Display(Prompt = "Введите логин")]
        [DataType(DataType.Text)]
        public string Login { get; set; }
        
        [Column("password")]
        [Display(Prompt = "Введите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
