using WebStoryFroEveryting.Models.CustomValidationAttribute;

namespace WebStoryFroEveryting.Models.Auth
{
    public class AuthViewModel
    {
        //[IsUniqName]
        public string UserName { get; set; }

        [AuthPassword]
        [IsStrongPassword]
        public string Password { get; set; }
    }
}
