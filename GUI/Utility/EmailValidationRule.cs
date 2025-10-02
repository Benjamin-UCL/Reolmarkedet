using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace GUI.Utility
{
    public class EmailValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string email = value as string;
            if (string.IsNullOrWhiteSpace(email))
            {
                return new ValidationResult(false, "Email cannot be empty.");
            }
            // Simple regex for email validation
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, pattern))
            {
                return new ValidationResult(false, "Invalid email format.");
            }
            return ValidationResult.ValidResult;
        }
    }
}
