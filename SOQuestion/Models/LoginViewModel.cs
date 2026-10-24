using System.ComponentModel.DataAnnotations;

namespace SOQuestion.Models
{
    public class LoginViewModel : MultiLanguageViewModel
    {
        public LoginViewModel() { }
        public LoginViewModel (HttpRequest request) : base(request)
        {
            ErrorEmailRequired = Translate(Translation.ERROR_EMAIL_REQUIRED);
            ErrorInvalidEmail = Translate(Translation.ERROR_INVALID_EMAIL);
            ErrorPasswordRequired = Translate(Translation.ERROR_PASSWORD_REQUIRED);
        }

        [MultiLanguageRequired(ErrorMessageId = Translation.ERROR_EMAIL_REQUIRED)]
        [MultiLanguageEmailAddress(ErrorMessageId = Translation.ERROR_INVALID_EMAIL)]
        public string Email { get; set; }
        [MultiLanguageRequired(ErrorMessageId = Translation.ERROR_PASSWORD_REQUIRED)]
        public string Password { get; set; }

        public string ErrorEmailRequired { get; set; }
        public string ErrorInvalidEmail { get; set; }
        public string ErrorPasswordRequired { get; set; }
    }
}
