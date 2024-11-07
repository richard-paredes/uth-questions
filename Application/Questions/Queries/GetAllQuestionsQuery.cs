using Application.Common.Interfaces;
using Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Questions.Queries
{
    public record GetAllQuestionsQuery : IRequest<List<QuestionDto>>;

    public class GetAllQuestionsQueryHandler : IRequestHandler<GetAllQuestionsQuery, List<QuestionDto>>
    {
        private readonly IQuestionsRepository _questionsRepository;
        public GetAllQuestionsQueryHandler(IQuestionsRepository questionsRepository)
        {
            _questionsRepository = questionsRepository;
        }

        public Task<List<QuestionDto>> Handle(GetAllQuestionsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_questionsRepository.GetAllQuestions()
                .Select(x => new QuestionDto(x.ProblemStatement, x.Choices.ToList(), x.CorrectChoice))
                .ToList());
        }
    }
}
