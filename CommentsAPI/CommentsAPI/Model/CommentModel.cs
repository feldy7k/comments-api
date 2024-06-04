using System.ComponentModel.DataAnnotations;

namespace CommentsAPI.Model
{
    public class CommentModel
    {
        [Required] // triggered when ModelState.IsValid
        [StringLength(1000, MinimumLength = 1)] // triggered when ModelState.IsValid
        [SanitizeInput("Content")] // triggered when ModelState.IsValid
        public string Content { get; set; }

        public CommentDetail CommentDetail { get; set; }
    }

    public class CommentDetail
    {
        [SanitizeInput("Author")] // triggered when ModelState.IsValid
        public string Author { get; set; }
    }
}
