using System;
using System.Collections.Generic;

namespace Pelnomocnik
{

    public class User
    {

        private bool HasAdminPrivilages;


        public User(bool isAdmin)
        {
            isAdmin = HasAdminPrivilages;
        }
        public void MakeAdmin()
        {
            HasAdminPrivilages = true;
        }

        public bool IsAdmin()
        {
            return HasAdminPrivilages;
        }

    }

    public interface Information
    {
        public abstract void DisplayData();
        public abstract void DisplayRestrictedData();
    }

    public class Database : Information
    {

        private Dictionary<string, double> Map;

        public Database()
        {
            Map = new Dictionary<string, double>();
            Map.Add("Zyzio MacKwacz", 2500.00);
            Map.Add("Scooby Doo", 11.40);
            Map.Add("Adam Mackiewicz", 15607.95);
            Map.Add("Rick Morty", 429.18);
        }

        public void DisplayData()
        {
            Console.WriteLine("Użytkownicy: ");
            foreach (var item in Map)
            {
                Console.WriteLine(item.Key);
            }
        }

        public void DisplayRestrictedData()
        {
            foreach (var item in Map)
            {
                Console.WriteLine(item.Key + " zarabia " + item.Value + " zł miesięcznie");
            }
        }

    }

    public class DatabaseGuard : Information
    {

        private Database DB;
        private User user;

        public DatabaseGuard(User u)
        {
            DB = new Database();
            user = u;
        }

        public void DisplayData()
        {
            DB.DisplayData();
        }

        public void DisplayRestrictedData()
        {
            if (user.IsAdmin())
            {
                DB.DisplayRestrictedData();
            }
            else Console.WriteLine("Nie masz wystarczających uprawnień");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {

            var Zbyszek = new User(false);
            var db = new DatabaseGuard(Zbyszek);

            db.DisplayData();

            Console.WriteLine("---------------------------------------------------------");

            db.DisplayRestrictedData();

            Console.WriteLine("---------------------------------------------------------");

            Zbyszek.MakeAdmin();
            db.DisplayRestrictedData();

        }
    }

}
