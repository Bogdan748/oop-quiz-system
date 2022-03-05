using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Library
{
    public class Quiz
    {
        public Quiz(Question[] questions)
        {
            Questions = questions;
        }
        public Question[] Questions { get; }
    }
}
