using System;


namespace QuizSystem.Library
{
    public class MultipleSelectionQuestion : Question
    {

        public MultipleSelectionQuestion(
            int id,
            string text,
            string[] options,
            int[] correctOptionsIndex)
            :base(id,text)
        {
            Options = options;
            CorrectOptionsIndex = correctOptionsIndex;
        }

        public string[] Options { get; }
        public int[] CorrectOptionsIndex { get; }


        public override decimal GetScoreForAnswer(string answer)
        {
            if (string.IsNullOrWhiteSpace(answer))
            {
                return 0M;
            }


            //transfer user input into array of idices
            string[] options = answer.Split(',', StringSplitOptions.RemoveEmptyEntries);
            int[] optionsIndices = new int[options.Length];
            for (int i=0; i < options.Length; i++)
            {
                if (!int.TryParse(options[i], out int optionIndex))
                {
                    return 0M;
                }

                optionsIndices[i] = optionIndex;
            }

            //correct answer must be the same size as user input
            if(CorrectOptionsIndex.Length != optionsIndices.Length)
            {
                return 0M;
            }

            //all correct options must be amoung user input
            foreach (int correctOptionIndex in CorrectOptionsIndex)
            {
                bool foundInUserReply = false;
                foreach(int userOptionsIndex in optionsIndices)
                {
                    if (correctOptionIndex == userOptionsIndex)
                    {
                        foundInUserReply = true;
                        break;
                    }
                }
                if (!foundInUserReply)
                {
                    return 0M;
                }

            }

            return 1;
        }

        public override void Render(int questionNo)
        {
            Console.WriteLine($"{questionNo}) {Text}");
            for (int i = 0; i < Options.Length; i++)
            {
                Console.WriteLine($"    {i}: {Options[i]}");
            }
            Console.Write("Please choose a one or more option indices (comma separated)=");
        }
    }
}
