using System;

namespace QuizSystem.Library
{
    public class QuizReply
    {
        public QuizReply(User user, Quiz quiz)
        {
            User = user;
            Quiz = quiz;
        }
        public User User { get; }

        public Quiz Quiz { get; }

        public decimal Score { get; private set; } = 0M;


        public void Solve()
        {
            //rezolvarea chestionarului

            for (int i = 0; i<Quiz.Questions.Length; i++)
            {
                Console.WriteLine();
                //afisez intrebare
                Question question = Quiz.Questions[i];
                
                question.Render(i + 1);

                //astept raspuns
                string userAnswer = Console.ReadLine();
                //interpretez si fac update
                decimal questionScore = question.GetScoreForAnswer(userAnswer);
                Score += questionScore;
            }



        }
    }
}
