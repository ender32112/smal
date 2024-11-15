using System;
using System.Collections.Generic;

namespace GuessTheNumber
{
    public class Registration
    {
        public static bool RegisterNewUser(string username, Dictionary<string, List<int>> userScores)
        {
            if (userScores.ContainsKey(username))
            {
                Console.WriteLine($"Пользователь с именем '{username}' уже существует.");
                return false;
            }
            userScores.Add(username, new List<int>());
            Console.WriteLine($"Пользователь '{username}' успешно зарегистрирован.");
            return true;
        }
    }
}