using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JSONSerialization
{
    public class Class1
    {

        public class YouTuber
        {
            public string Name;
            public string Channel;
            public bool Active;
            public int Age;
            public List<string> Employees;

        }
        static void Main(string[] args)
        {

            string json = System.IO.File.ReadAllText(@"C:\Users\user\Desktop\person.json");


            //Console.WriteLine(json);
            YouTuber deserialize = JsonConvert.DeserializeObject<YouTuber>(json);
            Console.WriteLine(deserialize.Name);
            Console.WriteLine(deserialize.Channel);
            Console.WriteLine(deserialize.Active);
            Console.WriteLine(deserialize.Age);
            foreach (var item in deserialize.Employees)
            {
                Console.WriteLine("Employees: " + item);
            }
            string serialised = JsonConvert.SerializeObject(deserialize);
            Console.WriteLine(serialised);
            Console.ReadKey();
        }
    }
}
