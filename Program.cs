
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using System.Text.Json;
using System.Reflection;
using System.Text.Json.Serialization;


namespace LinqLesson
{
    class Program  
    {
        static void Main(string[] args)
        {
            IEnumerable<Person> persons = new List<Person>();
            var comand = new JsonSerializerOptions();


            using (StreamReader streamReader = new StreamReader("data.json"))
            {
                var content = streamReader.ReadToEnd();
                persons = JsonSerializer.Deserialize<IEnumerable<Person>>(content, comand);
            }
            // 1 Task
            var farthestNorth = persons.Where(p => p.Latitude == persons.Max(p => p.Latitude)).FirstOrDefault();
            var farthestSouth = persons.Where(p => p.Latitude == persons.Min(p => p.Latitude)).FirstOrDefault();
            var farthestWest = persons.Where(p => p.Longitude == persons.Max(p => p.Longitude)).FirstOrDefault();
            var farthestEast = persons.Where(p => p.Longitude == persons.Min(p => p.Longitude)).FirstOrDefault();
            // 2 Task
//this task is not completed - find max and min distance between 2 persons
            // 3 Task
            var twoPersonWithLongestAbout = persons.OrderByDescending(p => p.About.WordsCount()).Take(2);

            // 4 Task

            var grooupByFriends = persons
               .SelectMany(person => person.Friends, (person, friend) => new { FriendName = friend.Name, PersonName = person.Name })
               .GroupBy(pf => pf.FriendName)
               .Where(pf => pf.Count() > 1)
               .ToList();
            foreach (var commonFriend in grooupByFriends)
            {
                Console.WriteLine($"{commonFriend.Key} is common friend for:");
                foreach (var person in commonFriend)
                {
                    Console.WriteLine(person.PersonName);
                }
                Console.WriteLine();
            }



        }


    }
}
 //checked   


