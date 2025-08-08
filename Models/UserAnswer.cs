mkdir -p Models
cat > Models/UserAnswer.cs <<'EOF'
using System;

namespace AIInterviewCoach.Models
{
    public class UserAnswer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string AnswerText { get; set; } = string.Empty;
        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
    }
}
EOF
