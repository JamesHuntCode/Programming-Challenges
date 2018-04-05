using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TheRabbitChallenge
{
    class Program
    {
        public static string path = Environment.CurrentDirectory + @"\rabbits.txt";

        static void Main(string[] args)
        {
            File.WriteAllText(path, string.Empty);
            long monthsNeeded = Reproduce(2, 4, 100000);
            Console.WriteLine(monthsNeeded.ToString());
            Console.Read();
        }

        static int Reproduce(int numberOfMaleRabbits, int numberOfFemaleRabbits, int numberOfHumans)
        {
            int numberOfMonthsPassed = 0;

            BirthRabbits(numberOfMaleRabbits, numberOfFemaleRabbits, 2);
            long numberOfRabbits = ReadRabbits();

            while ((numberOfHumans * 2) > numberOfRabbits)
            {
                numberOfMonthsPassed++;
                numberOfRabbits = ReadRabbits();

                using (StreamReader SR = new StreamReader(path))
                {
                    string[] parts = SR.ReadLine().Split(';');
                    int age = Convert.ToInt32(parts[0].Remove(0, 4));

                    if (!(parts[1].Contains("dead:true")))
                    {
                        if ((parts[1].Contains("female:true")) && (age >= 4))
                        {
                            BirthRabbits(4, 9, 0);
                        }

                        if (age >= 96)
                        {
                            // log to line rabbit:dead
                        }
                    }
                }
            }

            using (StreamReader SR = new StreamReader(path))
            {
                if (SR.ReadLine().Contains("dead:true"))
                {
                    // remove lines where dead:true occurs
                }
            }

                return numberOfMonthsPassed;
        }

        // Method to produce 14 new rabbits
        static void BirthRabbits(int numMales, int numFemales, int age)
        {
            // produce males
            for (int i = 0; i < numMales; i++)
            {
                using (StreamWriter SW = new StreamWriter(path, append: true))
                {
                    SW.WriteLine("age:" + Convert.ToString(age) + ";" + "female:false-dead:false");
                }
            }

            // produce females
            for (int i = 0; i < numFemales; i++)
            {
                using (StreamWriter SW = new StreamWriter(path, append: true))
                {
                    SW.WriteLine("age:" + Convert.ToString(age) + ";" + "female:true-dead:false");
                }
            }
        }

        // Read rabbits from text file
        static long ReadRabbits()
        {
            return File.ReadAllLines(path).Count();
        }
    }
}
