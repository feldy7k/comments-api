using System.ComponentModel.DataAnnotations;

namespace CommentsAPI.Model
{
    public class CommentModel
    {
        [Required] // triggered when ModelState.IsValid
        [StringLength(1000, MinimumLength = 1)] // triggered when ModelState.IsValid
        [SanitizeInput] // triggered when ModelState.IsValid
        public string Content { get; set; }
    }
}
