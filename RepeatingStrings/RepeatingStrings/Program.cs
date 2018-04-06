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
            string[] input = { "12", "11", "9", "1", "12" };

            string repeatingString = DetectRepeatingString(input);

            if (repeatingString.Length > 0)
            {
                string[] data = repeatingString.Split(';');
                Console.WriteLine("First repeating string is: '" + data[0] + "' located at index: " + data[1]);
                Console.Read();
            }
            else
            {
                Console.WriteLine("No repeating strings have been located within the input collection.");
                Console.Read();
            }
        }

        static string DetectRepeatingString(string[] collection)
        {
            string repeatingString = "";
            string index = "";

            string[] copy = collection;

            for (int i = 0; i < collection.Length; i++)
            {
                for (int j = 0; j < copy.Length; j++)
                {
                    if ((collection[i] == copy[j]) && (i != j))
                    {
                        repeatingString = collection[i];
                        index = j.ToString();
                        return repeatingString + ";" + index;
                    }
                }
            }

            return string.Empty; 
        }
    }
}
