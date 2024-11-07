namespace Domain.Entities
{
    /**
     * Different kinds of questions 
     * - True / False
     * - Multiple choice 
     */
    public enum QuestionType
    {
        MultipleChoice = 0,
        TrueFalse = 1
    }

    public abstract class Question
    {
        protected Question(string problemStatement, QuestionType questionType)
        {
            ProblemStatement = problemStatement;
            QuestionType = questionType;
        }

        public string ProblemStatement { get; set; } = string.Empty;
        public QuestionType QuestionType { get; set; }
        public abstract ICollection<string> Choices { get; }
        public abstract string CorrectChoice { get; }
    }
}
