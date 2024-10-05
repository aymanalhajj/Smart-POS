using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Smart_POS.Validators
{
    internal class InvoiceNoValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value is null or (object)"")
                return new ValidationResult(false, "هذا الحقل مطلوب");
            else if (value.ToString().Length > 3)
                return new ValidationResult(false, "Name cannot be more than 3 characters long.");


            //MessageBox.Show(value.ToString());
            return ValidationResult.ValidResult;
        }
    }

}
