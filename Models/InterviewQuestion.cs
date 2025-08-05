namespace AIInterviewCoach.Models
{
    public class InterviewQuestion
    {
        public string QuestionText { get; set; }
        public string ModelAnswer { get; set; }
        public string Difficulty { get; set; } // "Easy", "Medium", "Hard"
    }
}
