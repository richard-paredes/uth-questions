using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IQuestionsRepository
    {
        List<Question> GetAllQuestions();
        bool CreateQuestion(Question question);
        bool DeleteQuestionByProblemStatement(string problemStatement);
    }
}
