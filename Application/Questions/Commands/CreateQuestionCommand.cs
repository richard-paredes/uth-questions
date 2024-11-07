using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Questions.Commands
{
    public record CreateQuestionCommand : IRequest<bool>
    {
        public QuestionType QuestionType { get; set; } = QuestionType.MultipleChoice;
        public string ProblemStatement { get; set; } = string.Empty;
        public string CorrectChoice { get; set; } = string.Empty;
        public List<string> Choices { get; set; } = new List<string>();
    }

    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, bool>
    {
        private readonly IQuestionsRepository _questionsRepository;
        public CreateQuestionCommandHandler(IQuestionsRepository questionsRepository)
        {
            _questionsRepository = questionsRepository;
        }

        public Task<bool> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            // TODO: Validate

            // Create
            Question question = null!;
            if (request.QuestionType == QuestionType.MultipleChoice)
            {
                question = new MultipleChoiceQuestion(request.ProblemStatement, request.Choices, request.CorrectChoice);
            }
            else if (request.QuestionType == QuestionType.TrueFalse) 
            {
                question = new TrueFalseQuestion(request.ProblemStatement, bool.Parse(request.CorrectChoice));
            }

            if (question is null) { return Task.FromResult(false); }

            // Persist
            return Task.FromResult(_questionsRepository.CreateQuestion(question));
        }
    }
}
