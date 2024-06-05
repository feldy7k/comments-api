using CommentsAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace CommentsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : ControllerBase
    {
        string exampleDangerousString = "<script>alert('XSS Attack!');</script><img src='nonexistent.jpg' onerror='alert(\"XSS via onerror\");' /><a href='http://example.com' onclick='alert(\"XSS via onclick\");'>Click me</a><div onmouseover='alert(\"XSS via onmouseover\");'>Hover over me</div><input type='text' value='<script>alert(\"Injected\");</script>' />";

        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Route("CreateComment")]
        public IActionResult CreateComment([FromBody] CommentModel model)
        {
            if (ModelState.IsValid)
            {
                // Sanitize input manually
                model.Content = HtmlSanitizer.Sanitize(model.Content);

                // Save the comment to the database
                // db.Comments.Add(model);
                // db.SaveChanges();

                return Ok(new { message = "Comment created successfully" });
            }
            return BadRequest(ModelState);
        }
    }
}
