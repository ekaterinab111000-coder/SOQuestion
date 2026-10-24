using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace SOQuestion.Models
{
    public class MultiLanguageRequiredAttribute : RequiredAttribute
    {
        private Translation errorMessageId;
        public Translation ErrorMessageId
        {
            get { return errorMessageId; }
            set
            {
                errorMessageId = value;
                ErrorMessage = ((int)errorMessageId).ToString();
            }
        }
    }
    public class MultiLanguageEmailAddressAttribute : ValidationAttribute
    {
        private Translation errorMessageId;
        public Translation ErrorMessageId
        {
            get { return errorMessageId; }
            set
            {
                errorMessageId = value;
                ErrorMessage = ((int)errorMessageId).ToString();
            }
        }
        public override bool IsValid(object? value)
        {
            var emailChecker = new EmailAddressAttribute();
            return emailChecker.IsValid(value);
        }
    }
}
