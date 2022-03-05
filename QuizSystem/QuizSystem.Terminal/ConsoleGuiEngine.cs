using QuizSystem.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Terminal
{
    public class ConsoleGuiEngine : GuiEngine
    {
        public ConsoleGuiEngine(QuestionRenderer[] renderers) 
            :base(renderers)
        {

        }

        public override string GetQuestionReply()
        {
            return Console.ReadLine();
        }

        public override void GoToNextQuestion()
        {
            Console.WriteLine();
        }
    }
}
