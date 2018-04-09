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

            int accessIndex = 0;
            string shifted = "";
            char sub = ' ';

            for (int i = 0; i < repeatedKeyword.Length; i++)
            {
                // create shifted index alphabets
                adjustedAlphabet.Clear();
                temp = alphabet.Split(repeatedKeyword[i]);
                for (int j = 0; j < temp.Length; j++)
                {
                    adjustedAlphabet.Add(temp[j]);
                }
                adjustedAlphabet.Insert(adjustedAlphabet.Count(), repeatedKeyword[i].ToString());

                // locate index of letter in real alphabet
                accessIndex = alphabet.IndexOf(repeatedKeyword[i].ToString());

                // locate index in shifted alphabet
                shifted = string.Join("", adjustedAlphabet.ToArray().Reverse());
                sub = shifted[accessIndex];

                // push located value into encrypted message
                
            }

            //return new String(encodedMessage.ToArray());
            return alphabet + " ----- " + shifted;
        }

        // Method to decode message
        static string Decode(string input)
        {
            return "";
            // this method part of the bonus challenge
        }
    }
}
