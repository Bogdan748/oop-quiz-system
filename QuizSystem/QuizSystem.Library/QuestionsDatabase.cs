using System;

namespace QuizSystem.Library
{
    public static class QuestionsDatabase
    {
        
        public static Question[] Questions { get; private set; }

        public static void PopulateDatabase(Question[] questions) {
            Questions = questions;
                }

        public static Quiz Create(int nrOfQuestions)
        {
            //folosindu-ma de Questions, trebuie sa pot genera un quiz
            if (nrOfQuestions <= 0)
            {
                throw new ArgumentException(
                    $"The number of questions must be positive, value '{nrOfQuestions}' ia not valid",
                    nameof(nrOfQuestions));
            }

            Question[] selectedQuestions = new Question[nrOfQuestions];
            Random randomizer = new Random();
            int idxSelectedQuestions = 0;

            while(idxSelectedQuestions< nrOfQuestions)
            {
                int randomIndex = randomizer.Next(0, Questions.Length - 1);
                Question randomQuestion = Questions[randomIndex];

                bool isAlreadySelected = false;
                for (int i=0; i < idxSelectedQuestions; i++)
                {
                    if (selectedQuestions[i].Id == randomQuestion.Id)
                    {
                        isAlreadySelected = true;
                        break;
                    }
                }

                if(!isAlreadySelected)
                {
                    selectedQuestions[idxSelectedQuestions] = Questions[randomIndex];
                    idxSelectedQuestions++;
                }
               
            }

            return new Quiz(selectedQuestions);
        }
    }
}
