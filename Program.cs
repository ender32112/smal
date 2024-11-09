using System;

namespace GuessTheNumber
{
    public class GameLogic
    {
        public static int PlayGame(int maxNumber, int maxAttempts)
        {
            Random random = new Random();
            int secretNumber = random.Next(1, maxNumber + 1);
            int attempts = 0;
            int guess;

            Console.WriteLine($"Угадайте число от 1 до {maxNumber}. У вас {maxAttempts} попыток.");

            do
            {
                attempts++;
                Console.Write($"Попытка {attempts}: Введите число: ");
                if (int.TryParse(Console.ReadLine(), out guess))
                {
                    if (guess < secretNumber)
                    {
                        Console.WriteLine("Слишком мало!");
                    }
                    else if (guess > secretNumber)
                    {
                        Console.WriteLine("Слишком много!");
                    }
                    else
                    {
                        Console.WriteLine($"Вы угадали! Число было {secretNumber}. Вам потребовалось {attempts} попыток.");
                        return attempts;
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Попробуйте ещё раз.");
                    attempts--; // Не учитывать некорректный ввод как попытку
                }
            } while (attempts < maxAttempts);

            Console.WriteLine($"Вы не угадали. Число было {secretNumber}.");
            return -1; // -1 обозначает проигрыш
        }
    }
}
