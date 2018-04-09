using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AlphabetCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string demoInput = "snitch thepackagehasbeendelivered";

            Console.WriteLine("Keyword & Message to be enctryped: " + demoInput);

            string encodedMessage = Encode(demoInput);
            Console.WriteLine("\nEncryted Message: " + encodedMessage);

            string decodedMessage = Decode(encodedMessage);
            Console.WriteLine("\nDecoded Message: " + decodedMessage);

            Console.ReadKey();
        }

        // Method to encode message
        static string Encode(string input)
        {
            string[] data = input.Split();
            string keyword = data[0];
            string message = data[1];

            List<char> encodedMessage = new List<char>();

            List<char> repeated = new List<char>();

            int n = 0;
            for (int i = 0; i < message.Length; i++)
            {
                repeated.Add(keyword[n]);

                if (n == (keyword.Length - 1))
                {
                    n = 0;
                }
                else
                {
                    n++;
                }
            }

            string repeatedKeyword = new String(repeated.ToArray());

            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            string[] temp = { };
            List<string> adjustedAlphabet = new List<string>();

            for (int i = 0; i < repeatedKeyword.Length; i++)
            {
                adjustedAlphabet.Clear();
                temp = alphabet.Split(repeatedKeyword[i]);
                for (int j = 0; j < temp.Length; j++)
                {
                    adjustedAlphabet.Add(temp[j]);
                }
                adjustedAlphabet.Insert(adjustedAlphabet.Count(), repeatedKeyword[i].ToString());
            }

            //return new string(encodedMessage.ToArray());
            return String.Join(string.Empty, adjustedAlphabet.ToArray().Reverse());
        }

        // Method to decode message
        static string Decode(string input)
        {
            return "";
        }
    }
}
