using System;

namespace GuessTheNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string username;
            Console.Write("Введите имя пользователя: ");
            username = Console.ReadLine();

            if (!Authentication.RegisterUser(username))
            {
                //обработка ситуации если пользователь уже существует
                Console.WriteLine("Выберите действие: 1 - начать игру, 2 - посмотреть результаты");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    //запуск игры
                }
                else if (choice == "2")
                {
                    Authentication.ShowScores(username);
                }
            }
            else
            {
                //запуск игры
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