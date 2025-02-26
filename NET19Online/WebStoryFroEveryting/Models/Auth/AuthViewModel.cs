using WebStoryFroEveryting.Models.CustomValidationAttribute;

namespace WebStoryFroEveryting.Models.Auth
{
    public class AuthViewModel
    {
        //[IsUniqName]
        public string UserName { get; set; }

        [AuthPassword]
        public string Password { get; set; }
    }
}
