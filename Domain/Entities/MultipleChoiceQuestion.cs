using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MultipleChoiceQuestion : Question
    {
        private readonly List<string> ChoicesStrings;
        private readonly string CorrectChoiceString;

        public MultipleChoiceQuestion(string problemStatement, List<string> choices, string correctChoice) 
            : base(problemStatement, QuestionType.MultipleChoice)
        {
            ChoicesStrings = choices;
            CorrectChoiceString = correctChoice;
        }

        public override ICollection<string> Choices => ChoicesStrings;

        public override string CorrectChoice => CorrectChoiceString;
    }
}
