using System;
using System.Collections.Generic;

namespace GuessTheNumber
{
    public class Authentication
    {
        private static Dictionary<string, List<int>> userScores = new Dictionary<string, List<int>>();

        public static bool RegisterUser(string username)
        {
            if (userScores.ContainsKey(username))
            {
                Console.WriteLine("Пользователь с таким именем уже существует.");
                return false;
            }
            userScores.Add(username, new List<int>());
            Console.WriteLine($"Пользователь {username} успешно зарегистрирован.");
            return true;
        }

        public static void SaveScore(string username, int score)
        {
            userScores[username].Add(score);
        }

        public static void ShowScores(string username)
        {
            if (userScores.ContainsKey(username))
            {
                Console.WriteLine($"Результаты пользователя {username}:");
                if (userScores[username].Count > 0)
                {
                    foreach (int score in userScores[username])
                    {
                        Console.WriteLine(score == -1 ? "Проигрыш" : $"Количество попыток: {score}");
                    }
                }
                else
                {
                    Console.WriteLine("Нет сохраненных результатов.");
                }
            }
            else
            {
                Console.WriteLine($"Пользователь {username} не найден.");
            }
        }
    }
}

