using System;
using System.Collections.Generic;

namespace Exercise
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //BEGIN SOLUTION
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("f.e", "for example");
            dict.Add("etc.", "and so on");
            dict.Add("i.e", "more precisely");

            PrintKeys(dict);
            Console.WriteLine("---");
            PrintKeysWhere(dict, "i");
            Console.WriteLine("---");
            PrintValuesOfKeysWhere(dict, ".e");
            //END SOLUTION
            //STUB: Console.WriteLine("Hello World!");
        }

        public static void PrintKeys(Dictionary<string, string> dict)
        {
            //BEGIN SOLUTION
            foreach (KeyValuePair<string, string> entry in dict) {
                Console.WriteLine(entry.Key);
            }
            //END SOLUTION
            /* STUB: Console.WriteLine("Hello World twice");
            Console.WriteLine("Hello World twice"); */
        }

        //BEGIN SOLUTION
        public static void PrintKeysWhere(Dictionary<string, string> dict, string text)
        {
            foreach (KeyValuePair<string, string> entry in dict) {
                if (entry.Key.Contains(text)) {
                    Console.WriteLine(entry.Key);
                }
            }
        }
        //END SOLUTION

        public static void PrintValuesOfKeysWhere(Dictionary<string, string> dict, string text)
        {
            foreach (KeyValuePair<string, string> entry in dict) {
                if (entry.Key.Contains(text)) {
                    Console.WriteLine(entry.Value);
                }
            }
        }
    }
}

