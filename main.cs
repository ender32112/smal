using System;

namespace GuessTheNumber
{
    class Program
    {
        static string dataFilePath = "userScores.txt"; // путь к файлу сохранения
        static Dictionary<string, List<int>> userScores = new Dictionary<string, List<int>>();

        static void Main(string[] args)
        {
            string username;
            Console.Write("Введите имя пользователя: ");
            username = Console.ReadLine();

            LoadScores();

            if (!Login.AuthenticateUser(username, userScores))
            {
                if (Registration.RegisterNewUser(username, userScores))
                {
                    PlayGame(username);
                }
            }
            else
            {
                PlayGame(username);
            }

            SaveScores();
        }


        Console.WriteLine("Выберите уровень сложности:");
            Console.WriteLine("1. Легкий (число от 1 до 10, 5 попыток)");
            Console.WriteLine("2. Средний (число от 1 до 50, 7 попыток)");
            Console.WriteLine("3. Сложный (число от 1 до 100, 10 попыток)");

            int choice = int.Parse(Console.ReadLine());
            int maxNumber, maxAttempts;

            switch (choice)
            {
                case 1:
                    maxNumber = 10;
                    maxAttempts = 5;
                    break;
                case 2:
                    maxNumber = 50;
                    maxAttempts = 7;
                    break;
                case 3:
                    maxNumber = 100;
                    maxAttempts = 10;
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    return;
            }

            int score = GameLogic.PlayGame(maxNumber, maxAttempts);
            Authentication.SaveScore(username, score);
            Authentication.ShowScores(username);
        }
    }
}