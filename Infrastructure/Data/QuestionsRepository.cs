using Application.Common.Interfaces;
using Domain.Entities;
using System.Collections.Immutable;

namespace Infrastructure.Data
{
    public class QuestionsRepository : IQuestionsRepository
    {
        private readonly List<Question> questions = new List<Question>();
        public bool CreateQuestion(Question question)
        {
            questions.Add(question);
            return true;
        }

        public bool DeleteQuestionByProblemStatement(string problemStatement)
        {
            var foundQuestion = questions.FirstOrDefault(x => x.ProblemStatement.Trim() == problemStatement.Trim());
            if (foundQuestion is null)
            {
                return false;
            }

            return questions.Remove(foundQuestion);
        }

        public List<Question> GetAllQuestions()
        {
            return questions;
        }
    }
}
