using Application.Questions.Commands;
using Application.Questions.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UTHealthQuestionBank.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly ISender _sender;

        public QuestionsController(ISender sender)
        {
            _sender = sender;
        }

        public async Task<IActionResult> Index()
        {
            var questions = await _sender.Send(new GetAllQuestionsQuery());
            return View(questions);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateQuestionCommand command, CancellationToken cancellationToken)
        {
            var successful = await _sender.Send(command, cancellationToken);
            // TODO: add logic if not successful to return the validation failures.
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(string problemStatement, CancellationToken cancellationToken)
        {
            var successful = await _sender.Send(new DeleteQuestionCommand(problemStatement), cancellationToken);
            // TODO: add logic if not successful 
            return RedirectToAction(nameof(Index));
        }
    }
}
