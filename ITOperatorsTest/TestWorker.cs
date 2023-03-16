using ClassLib;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ITOperatorsTest
{
    internal class TestWorker
    {
        public void Start()
        {
            try
            {
                //Opg 1.
                List<Car>? carlist = LoadJson();
                if(carlist != null)
                {
                    Console.WriteLine("Opg 1.");
                    Console.WriteLine("Press 'Enter' to show Car Data");
                    Console.ReadLine();
                    foreach (Car car in carlist)
                    {
                        Console.WriteLine(car.ToString());
                    }
                    Console.WriteLine("-----------------------------------------------------------");
                    
                }
                //Opg 2.
                Console.WriteLine("Opg 2.");
                List<string> namelist = new List<string>();
                foreach(var car in carlist)
                {
                    if (car.Name.Length > 0)
                    {
                        var str = car.Name.Split(" ").FirstOrDefault();
                        namelist.Add(str);
                    }
                }
                Console.WriteLine("Press 'Enter' to show the number of brand occurrences");
                Console.ReadLine();
                var g = namelist.GroupBy(i => i);
                foreach (var grp in g)
                {
                    Console.WriteLine("{0} - {1}", grp.Key, grp.Count());
                }
                Console.WriteLine("-----------------------------------------------------------");

                //Opg 3.
                Console.WriteLine("Opg 3.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public List<Car>? LoadJson()
        {
            Console.WriteLine("Loading Json...");
            
            string file = @"c:\temp\cars.json";
            
            if (File.Exists(file))
            {
                Console.WriteLine("Found File...");

                string JSONtxt = File.ReadAllText(file);
                List<Car> carlist = JsonConvert.DeserializeObject<List<Car>>(JSONtxt);
                return carlist;

            }
            return null;

        }
    }
}
