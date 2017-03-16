using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Assignment2ListsandMoreLists.Models;

namespace Assignment2ListsandMoreLists
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new List<Models.User>();

            //Populate initial set of users
            users.Add(new Models.User { Name = "Dave", Password = "hello" });
            users.Add(new Models.User { Name = "Steve", Password = "steve" });
            users.Add(new Models.User { Name = "Lisa", Password = "hello" });

            //Display Initial set of users:
            var initial = string.Join(Environment.NewLine, users.Select(x => string.Format($"Name: {x.Name}, Password: {x.Password}")));

            Console.WriteLine("Initial set of users:");
            Console.WriteLine(initial);
            Console.WriteLine("-----------------------------------------");

            //Display only users which have a password of hello

            var onlyhello = string.Join(Environment.NewLine, users.Where(x => x.Password.ToUpper().Contains("HELLO")).Select(x=>string.Format($"Name: {x.Name}, Password: {x.Password}")));

            Console.WriteLine($"Users which have a password of Hello:");
            Console.WriteLine(onlyhello);
            Console.WriteLine("-----------------------------------------");

            //Remove users which have a password that matches their username in lowercase

            var removePassword = users.ToList();
            removePassword.RemoveAll(x => x.Name.ToLower().Contains(x.Password.ToLower()));
            var removedMatchingPassword = string.Join(Environment.NewLine, removePassword.Select(x => string.Format($"Name: {x.Name}, Password: {x.Password}")));

            Console.WriteLine("Removed users where username equaled lowercase password:");
            Console.WriteLine(removedMatchingPassword);
            Console.WriteLine("-----------------------------------------");

            //Remove first user which has a password of hello

            var removeFirstHello = users.ToList();
            removeFirstHello.Remove(removeFirstHello.First(x=>x.Password.ToUpper().Contains("HELLO")));
            var removedFirstHello = string.Join(Environment.NewLine, removeFirstHello.Select(x => string.Format($"Name: {x.Name}, Password: {x.Password}")));

            //Of the remaining users, remove the first user which has a password of hello
            Console.WriteLine("Removed first user with a password of hello:");
            Console.WriteLine(removedFirstHello);
            Console.WriteLine("-----------------------------------------");

        }
    }
}
