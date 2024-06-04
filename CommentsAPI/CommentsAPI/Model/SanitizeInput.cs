using Microsoft.Extensions.Primitives;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace CommentsAPI.Model
{
    public class SanitizeInput : ValidationAttribute
    {
        private string _propertyName = "";
        public SanitizeInput(string propertyName)
        {
            _propertyName = propertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string stringValue = value as string;

            // Get the property info of the nested property
            PropertyInfo property = validationContext.ObjectType.GetProperty(_propertyName);
            if (property == null)
            {
                return new ValidationResult($"Property '{_propertyName}' not found.");
            }

            // Modify the property value
            property.SetValue(validationContext.ObjectInstance, HtmlSanitizer.Sanitize(stringValue), null);


            // validation is successful
            return ValidationResult.Success;
        }

    }
}
