using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AIInterviewCoach.Models;

namespace AIInterviewCoach.Pages
{
    public class AskModel : PageModel
    {
        [BindProperty]
        public UserAnswer UserAnswer { get; set; } = new UserAnswer();

        public string QuestionText { get; set; } = "Sample question for now.";

        public void OnGet()
        {
            // Load actual question here later if needed
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Store the answer temporarily
            TempData["LastAnswer"] = UserAnswer.AnswerText ?? string.Empty;

            // Redirect to a result page (should exist as Pages/Result.cshtml)
            return RedirectToPage("Result");
        }
    }
}

