using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TrueFalseQuestion : Question
    {
        private readonly bool CorrectChoiceBool;
        public TrueFalseQuestion(string problemStatement, bool correctChoice) 
            : base(problemStatement, QuestionType.TrueFalse)
        { 
            CorrectChoiceBool = correctChoice;
        }

        public override ICollection<string> Choices { 
            get => new List<string>
            {
                "true", "false"
            }; 
        }
        public override string CorrectChoice { get => CorrectChoiceBool.ToString(); }
    }
}
