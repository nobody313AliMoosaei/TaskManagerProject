using System.ComponentModel.DataAnnotations;

namespace TaskManagerRoom308.DTO.AddNewUser
{
    public class addNewUserCommand
    {
        [Required(ErrorMessage ="ارسال نام اجباری است")]
        public string FisrtName { get; set; }
        [Required(ErrorMessage = "ارسال نام خانوادگی اجباری است")]
        public string LastName { get; set; }
        [Required(ErrorMessage ="ارسال شماره اجباری است")]
        public string PhoneNumber { get; set; }
        public string NationalCode { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
