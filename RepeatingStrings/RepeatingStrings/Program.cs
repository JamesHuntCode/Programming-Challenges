using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepeatingStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = { "12", "11", "9", "1", "12", "2", "8", "9", "7", "2", "13" };

            bool repeatDetected = DetectRepeatingString(input);

            if (repeatDetected)
            {
                Console.WriteLine("First repeating string is: ");
            }
            else
            {
                Console.WriteLine("No repeating strings have been located within the input collection.");
            }
        }

        static bool DetectRepeatingString(string[] collection)
        {
            return false;
        }
    }
}
