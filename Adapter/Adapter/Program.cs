using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using static WzorzecAdapter.UsersApiAdapter;

namespace WzorzecAdapter
{
    public class UsersApi
    {
        public async Task<string> GetUsersXmlAsync()
        {
            var apiResponse = "<?xml version= \"1.0\" encoding= \"UTF-8\"?><users><user name=\"John\" surname=\"Doe\"/><user name=\"John\" surname=\"Wayne\"/><user name=\"John\" surname=\"Rambo\"/></users>";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(apiResponse);

            return await Task.FromResult(doc.InnerXml);
        }
    }

    public class UsersCSV
    {
        public static string[] Getuser(string path)
        {
            string[] readText = File.ReadAllLines(path);
            return readText;
        }
    }


    public interface IUserRepository
    {
        List<List<string>> GetUserNames();
    }

    public class UsersApiAdapter : IUserRepository
    {
        private UsersApi _adaptee = null;

        public UsersApiAdapter(UsersApi adaptee)
        {
            _adaptee = adaptee;
        }

        public List<List<string>> GetUserNames()
        {
            string incompatibleApiResponse = this._adaptee
              .GetUsersXmlAsync()
              .GetAwaiter()
              .GetResult();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(incompatibleApiResponse);

            var rootEl = doc.LastChild;

            List<List<string>> users = new List<List<string>>();

            if (rootEl.HasChildNodes)
            {
                List<string> user = new List<string> { };
                foreach (XmlNode node in rootEl.ChildNodes)
                {
                    user = new List<string> { node.Attributes["name"].InnerText, node.Attributes["surname"].InnerText };
                    users.Add(user);
                }
            }
            return users;
        }

        public class UserCSVAdapter
        {
            public string path;

            public UserCSVAdapter(string path)
            {
                this.path = path;
            }
            public string[] UserCSVAdapterChange()
            {
                string[] a = UsersCSV.Getuser($@"{path}");

                string[] b = new string[a.Length];
                int i = 1;
                foreach (var item in a)
                {
                    b[i - 1] = i.ToString().PadLeft(2) + ". " + item.Replace(',', ' ');
                    i++;

                }
                return b;
            }
        }

    }


    public class Program
    {

        static void Main(string[] args)
        {

            UsersApi usersRepository = new UsersApi();
            IUserRepository adapter = new UsersApiAdapter(usersRepository);

            Console.WriteLine("Użytkownicy z API:");
            List<List<string>> users = adapter.GetUserNames();
            int i = 1;
            users.ForEach(user =>
            {
                Console.WriteLine(i.ToString().PadLeft(2) + ". " + user[0] + " " + user[1]);
                i++;
            });


            Console.WriteLine();

            i = 1;
            Console.WriteLine("Użytkownicy z CSV:");
            UserCSVAdapter userCSV = new UserCSVAdapter("users.csv");
            string[] a = userCSV.UserCSVAdapterChange();
            foreach (var item in a)
            {
                Console.WriteLine(item);
            }
        }
    }
}

