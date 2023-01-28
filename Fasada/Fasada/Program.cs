using System;
using SystSystemem.Collections.Generic;
using System.Text.RegularExpressions;

namespace WzorzecFasada
{

    interface IUserService
    {
        void CreateUser(string email);
        void DeleteUser(string email);
        void UserCount();
    }

    static class EmailNotification
    {
        public static void SendEmail(string to, string subject)
        {
            Console.WriteLine($"{subject}{to}");
        }
    }

    class UserRepository
    {
        private readonly List<string> users = new List<string>
        {
            "john.doe@gmail.com", "sylvester.stallone@gmail.com"
        };

        public int UsersCount()
        {
            return users.Count;
        }

        public bool IsEmailFree(string email)
        {

            return !users.Contains(email);
        }


        public void AddUser(string email)
        {
            users.Add(email);
        }

        public void DeleteUser(string email)
        {
            users.Remove(email);
        }
    }

    static class Validators
    {
        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase);
        }
    }

    class UserService : IUserService
    {
        private readonly UserRepository userRepository = new UserRepository();
        public void CreateUser(string email)
        {
            if (!Validators.IsValidEmail(email))
            {
                throw new ArgumentException("Błędny email");
            }

            if (!userRepository.IsEmailFree(email))
            {
                throw new ArgumentException("Ktoś ma już taki email");
            }

            userRepository.AddUser(email);
            EmailNotification.SendEmail(email, "Welcome to our service ");
        }
        public void DeleteUser(string email)
        {
            if (!Validators.IsValidEmail(email))
            {
                throw new ArgumentException("Błędny email");
            }
            if (userRepository.IsEmailFree(email))
            {
                throw new ArgumentException("Nie ma takiego użytkownika");
            }

            userRepository.DeleteUser(email);
            EmailNotification.SendEmail(email, "Goodbye ");
        }
        public void UserCount()
        {
            Console.WriteLine("Aktualna liczba adresów: " + userRepository.UsersCount());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IUserService userService = new UserService();
            userService.UserCount();
            userService.CreateUser("someemail@gmail.com");
            userService.UserCount();
            userService.DeleteUser("john.doe@gmail.com");
            userService.UserCount();
        }
    }

}