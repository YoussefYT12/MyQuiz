using System.ComponentModel.DataAnnotations;

namespace MyQuiz.Front.Models
{
    public class UserLoginAdmin
    {
        [Required(ErrorMessage = "Required")]
        public string AdminName { get; set; }

        [Required(ErrorMessage = "Required")]
        public int Password { get; set; }
    }
}
