using System;
using System.Collections.Generic;
using System.Linq;
using AIInterviewCoach.Models;

namespace AIInterviewCoach.Services
{
    public class QuestionService
    {
        private List<InterviewQuestion> AllQuestions;

        public List<InterviewQuestion> ShuffledQuestions { get; private set; }
        public List<UserAnswer> UserAnswers { get; private set; } = new List<UserAnswer>();

        public QuestionService()
        {
            AllQuestions = new List<InterviewQuestion>
            {
                new InterviewQuestion { QuestionText = "Tell me about yourself.", ModelAnswer = "Talk briefly about your background...", Difficulty = "Easy" },
                new InterviewQuestion { QuestionText = "Why should we hire you?", ModelAnswer = "Because I can bring value through...", Difficulty = "Medium" },
                // Add more questions up to 100 grouped by difficulty
            };

            // Shuffle logic
            var random = new Random();
            ShuffledQuestions = AllQuestions
                .GroupBy(q => q.Difficulty)
                .SelectMany(g => g.OrderBy(x => random.Next()).Take(g.Key == "Easy" ? 2 : g.Key == "Medium" ? 2 : 1))
                .ToList();
        }

        public void AddUserAnswer(string question, string givenAnswer)
        {
            var match = AllQuestions.FirstOrDefault(q => q.QuestionText == question);
            int marks = 0;

            if (match != null)
            {
                marks = EvaluateAnswer(givenAnswer, match.ModelAnswer);
            }

            UserAnswers.Add(new UserAnswer
            {
                Question = question,
                GivenAnswer = givenAnswer,
                Marks = marks
            });
        }

        private int EvaluateAnswer(string given, string model)
        {
            if (string.IsNullOrWhiteSpace(given)) return 0;

            // Simple similarity scoring
            int score = 0;
            var modelWords = model.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in modelWords)
            {
                if (given.Contains(word, StringComparison.OrdinalIgnoreCase))
                {
                    score++;
                }
            }

            // Normalize to 10 marks
            return Math.Min(10, score * 10 / modelWords.Length);
        }
    }
}
