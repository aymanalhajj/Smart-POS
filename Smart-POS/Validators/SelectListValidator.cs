using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Smart_POS.Validators
{
    public class SelectListValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value is null or (object)"")
                return new ValidationResult(false, "هذا الحقل مطلوب");
            return ValidationResult.ValidResult;
        }
    }
}
