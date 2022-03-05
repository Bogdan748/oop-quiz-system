
using System;

namespace QuizSystem.Library
{
    public class SingleSelectionQuestion : Question
    {
        public SingleSelectionQuestion(
            int id,
            string text,
            string[] options,
            int correctAnswerIndex)
            :base(id,text)
        {
            Options = options;
            CorrectOptionIndex = correctAnswerIndex;
        }
        public string[] Options { get; }
        public int CorrectOptionIndex { get; }

        public override decimal GetScoreForAnswer(string answer)
        {

            if (string.IsNullOrEmpty(answer))
            {
                return 0M;
            }

            if(!int.TryParse(answer, out int resultIdenx))
            {
                return 0M;
            }

            return (resultIdenx == CorrectOptionIndex
                ? 1M
                : 0M);
        }
        
    }
}
