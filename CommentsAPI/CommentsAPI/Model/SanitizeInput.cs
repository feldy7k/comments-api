using System.ComponentModel.DataAnnotations;

namespace CommentsAPI.Model
{
    public class SanitizeInput : ValidationAttribute
    {
        public SanitizeInput()
        {

        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // modifying the property value
            var instance = validationContext.ObjectInstance as CommentModel;
            if (instance != null)
            {
                instance.Content = HtmlSanitizer.Sanitize(instance.Content); // Sanitize the value
            }

            // validation is successful
            return ValidationResult.Success;
        }

    }
}
