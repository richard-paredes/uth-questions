using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Questions.Commands
{
    public record DeleteQuestionCommand(string ProblemStatement) : IRequest<bool>;
    public class DeleteQuestionCommandHandler : IRequestHandler<DeleteQuestionCommand, bool>
    {
        private readonly IQuestionsRepository _questionsRepository;

        public DeleteQuestionCommandHandler(IQuestionsRepository questionsRepository)
        {
            _questionsRepository = questionsRepository;
        }

        Task<bool> IRequestHandler<DeleteQuestionCommand, bool>.Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
        {
            var successful = _questionsRepository.DeleteQuestionByProblemStatement(request.ProblemStatement);

            return Task.FromResult(successful);
        }
    }
}
