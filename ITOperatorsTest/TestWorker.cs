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
                Console.WriteLine("Press 'Enter' to show the number of ford cars made after 1980/01/01");
                Console.ReadLine();
                List<Car> fordlist = new List<Car>();
                foreach(var car in carlist)
                {
                    DateTime comparedTo = new DateTime(1980,1,1);
                        
                    DateTime carYear = DateTime.Parse(car.Year);
                    if(car.Origin == "Ford" && carYear < comparedTo)
                    {
                        fordlist.Add(car);
                    }
                }
                Console.WriteLine(fordlist.Count);

                Console.WriteLine("-----------------------------------------------------------");

                //Opg 4.
                Console.WriteLine("Opg 4.");
                Console.WriteLine("Press 'Enter' to show the average horsepower on the different car origins");
                Console.ReadLine();

                List<string> originList = new List<string>();
                foreach (var origin in carlist)
                {
                    if (!originList.Contains(origin.Origin))
                    {
                        originList.Add(origin.Origin);
                    }
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public List<Car>? LoadJson()
        {
            Console.WriteLine("Loading Json...");
            
            string file = @"..\..\..\cars.json";
            
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
