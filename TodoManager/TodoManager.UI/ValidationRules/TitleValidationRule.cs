using System.Globalization;
using System.Windows.Controls;

namespace TodoManager.UI.ValidationRules
{
    public class TitleValidationRule : ValidationRule
    {
        private const int TitleMinLength = 4;
        private const int TitleMaxLength = 30;

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string objectAsString = (string)value; 
            bool isValidTitle = objectAsString.Length >= TitleMinLength && objectAsString.Length <= TitleMaxLength;
            
            if (isValidTitle)
            {
                return new ValidationResult(true, null);
            }

            return new ValidationResult(false, $"Username should be between {TitleMinLength} and {TitleMaxLength} symbol!");
        }
    }
}
