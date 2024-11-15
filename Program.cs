using System;
using System.Collections.Generic;

namespace GuessTheNumber
{
    public class Login
    {
        public static bool AuthenticateUser(string username, Dictionary<string, List<int>> userScores)
        {
            if (userScores.ContainsKey(username))
            {
                Console.WriteLine($"Добро пожаловать, {username}!");
                return true;
            }
            else
            {
                Console.WriteLine($"Пользователь с именем '{username}' не найден.");
                return false;
            }
        }
    }
}
