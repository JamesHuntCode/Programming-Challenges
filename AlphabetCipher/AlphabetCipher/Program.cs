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

            Console.WriteLine("Keyword & Message to be encryped: " + demoInput);

            string encodedMessage = Encode(demoInput);
            Console.WriteLine("\nEncryted Message: " + encodedMessage);

            string decodedMessage = Decode(encodedMessage);
            Console.WriteLine("\nDecoded Message: " + decodedMessage);

            Console.ReadKey();
        }

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
            List<string> newAlphabet = new List<string>();

            for (int i = 0; i < message.Length; i++)
            {
                int sortedAlphabetIndex = alphabet.IndexOf(repeatedKeyword[i]);

                string[] arr = alphabet.Split(message[i]);
                newAlphabet.Clear();
                for (int j = arr.Length - 1; j >= 0; j--)
                {
                    newAlphabet.Add(arr[j]);
                }
                newAlphabet.Insert(0, message[i].ToString());

                string str = string.Join(string.Empty, newAlphabet);
                encodedMessage.Add(str[sortedAlphabetIndex]);
            }
            return String.Join(string.Empty, encodedMessage);
        }

        static string Decode(string input)
        {
            return "";
            // this method part of the bonus challenge
        }
    }
}
