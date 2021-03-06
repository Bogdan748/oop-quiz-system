using QuizSystem.Library;
using System;

namespace QuizSystem.Terminal
{
    class Program
    {
        static void Main(string[] args)
        {
            SetupDatabase();

            Console.Write("Your email address: ");
            string email = Console.ReadLine();

            Quiz quiz = QuestionsDatabase.Create(2);
            User user = new User(email);


            QuizReply userReply = new QuizReply(user, quiz);
            ConsoleGuiEngine guiEngine = new ConsoleGuiEngine(
                new QuestionRenderer[]
                {
                    new SingleSelectionQuestionRenderer(),
                    new MultipleSelectionQuestionRenderer()
                }
                );

            userReply.Solve(guiEngine);

            Console.WriteLine();
            Console.Write($"Congrats, you achieved {userReply.Score} points!!!");

        }

        private static void SetupDatabase()
        {

            int id = 1;
            QuestionsDatabase.PopulateDatabase(new Question[]
            {
                new SingleSelectionQuestion(
                    id++,
                    "Choose ypur preffered fruid:",
                    new[]{
                            "Apples","Oranges","Bananas"
                       },
                    1),

                new MultipleSelectionQuestion(
                    id++,
                    "What is the best smartphone brand:",
                    new[]{
                            "Apple","Samsung","LG"
                       },
                    new[] {0,1 }),

                new SingleSelectionQuestion(
                    id++,
                    "Wich is the best operating system:",
                    new[]{
                            "Window","MacOS","Ubuntu"
                       },
                    2),

                new MultipleSelectionQuestion(
                    id++,
                    "Who build the best electri cars:",
                    new[]{
                            "Tesla","Renauld","Dacia"
                       },
                    new[] { 0,2}),
            }) ;


        }
    }
}
