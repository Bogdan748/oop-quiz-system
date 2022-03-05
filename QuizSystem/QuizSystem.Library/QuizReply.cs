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


        public void Solve(GuiEngine guiEngine)
        {
            guiEngine.GoToNextQuestion();
            //rezolvarea chestionarului

            for (int i = 0; i<Quiz.Questions.Length; i++)
            {
                
                //afisez intrebare
                Question question = Quiz.Questions[i];
                QuestionRenderer questionRenderer=  guiEngine.GetRendererForQuestion(question);
                questionRenderer.RenderQuestion(i + 1, question);

                

                //astept raspuns
                string userAnswer = guiEngine.GetQuestionReply();
                //interpretez si fac update
                decimal questionScore = question.GetScoreForAnswer(userAnswer);
                Score += questionScore;
            }



        }
    }
}
