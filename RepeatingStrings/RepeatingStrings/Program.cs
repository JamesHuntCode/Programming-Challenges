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

            List<string> checkedStrings = new List<string>();

            for (int i = 0; i < collection.Length; i++)
            {
                if (checkedStrings.Count() > 0)
                {
                    for (int j = 0; j < checkedStrings.Count; j++)
                    {
                        if (collection[i] == checkedStrings[j])
                        {
                            repeatingString = collection[i];
                            index = i.ToString();
                        }
                    }
                }
                else
                {
                    checkedStrings.Add(collection[i]);
                }
            }

            if (repeatingString.Length > 0) { return repeatingString + ";" + index; }
            else { return string.Empty; }
        }
    }
}
