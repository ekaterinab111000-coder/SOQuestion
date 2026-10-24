using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SOQuestion.Models
{
    public class MultiLanguageViewModel
    {
        private static Dictionary<int, Dictionary<Translation, string>> _translations;
        static MultiLanguageViewModel()
        {
            var english = new Dictionary<Translation, string>()
            {
                { Translation.ERROR_EMAIL_REQUIRED, "Email Address is a required field" },
                { Translation.ERROR_INVALID_EMAIL, "Not a valid Email Address" },
                { Translation.ERROR_PASSWORD_REQUIRED, "Password is a required field" }
            };
            var croation = new Dictionary<Translation, string>()
            {
                { Translation.ERROR_EMAIL_REQUIRED, "Adresa e-pošte je obavezno polje" },
                { Translation.ERROR_INVALID_EMAIL, "Neispravna adresa e-pošte" },
                { Translation.ERROR_PASSWORD_REQUIRED, "Lozenica je obavezno polje" }
            };
            _translations = new Dictionary<int, Dictionary<Translation, string>>()
            {
                { 1, english },
                { 2, croation }
            };
        }
        public MultiLanguageViewModel() 
        { 
        }
        public MultiLanguageViewModel(HttpRequest request)
        {
            //In production this will be filled from a database
            LanguageId = request.HttpContext.Session.GetInt32("languageid") ?? 1;
        }
        public static Dictionary<int, string> Languages { get; set; } = new Dictionary<int, string>()
        {
            { 1, "English" },
            { 2, "Hrvatski" }
        };
        public int LanguageId { get; set; }
        public string Translate(Translation key)
        {
            return _translations[LanguageId][key];
        }
        public static void TranslateModelState(ModelStateDictionary modelState, int languageId)
        {
            var tmpValues = new ModelStateDictionary();
            foreach(var item in modelState)
            {
                if (item.Value.Errors.Any())
                {
                    string msg = item.Value.Errors[0].ErrorMessage;
                    if (msg.Length < 5)
                    {
                        //ErrorMessage is numeric code
                        Translation key = (Translation)int.Parse(msg);
                        tmpValues.AddModelError(item.Key, _translations[languageId][key]);
                    }
                    else
                    {
                        tmpValues.AddModelError(item.Key, msg);
                    }
                }
            }
            modelState.Clear();
            foreach(var item in tmpValues)
            {
                modelState.AddModelError(item.Key, item.Value.Errors[0].ErrorMessage);
            }
        }
    }
    public enum Translation
    {
        ERROR_EMAIL_REQUIRED = 1,
        ERROR_INVALID_EMAIL = 2,
        ERROR_PASSWORD_REQUIRED = 3
    }
}
