using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;


namespace Lab1{
    class Program{
        static IList<string> words = new List<string>();
        static void Main(string[] args){

            bool flag = true;
           
            while (flag){
                
                Console.WriteLine("1 - Import Words from File");
                Console.WriteLine("2 - Bubble Sort words");
                Console.WriteLine("3 - LINQ/Lambda sort words");
                Console.WriteLine("4 - Count the Distinct Words");
                Console.WriteLine("5 - Take the first 10 words");
                Console.WriteLine("6 - Get the number of words that start with 'j' and display the count");
                Console.WriteLine("7 - Get and display of words that end with 'd' and display the count");
                Console.WriteLine("8 - Get and display of words that are greater than 4 characters long, and display the count");
                Console.WriteLine("9 - Get and display of words that are less than 3 characters long and start with the letter 'a', and display the count");
                Console.WriteLine("x – Exit");
                Console.WriteLine("\r\nMake a selection: ");

                string num = Console.In.ReadLine();
                Console.Clear();

                switch (num){
                    
                    case "1":
                        Program.Import();
                        break;

                    case "2":
                        List<string> bubbleSort = Program.words.ToList<string>();
                        DateTime timeA = DateTime.Now;
                        Program.bubbleSort(bubbleSort);
                        Console.WriteLine("Time used to sort: " + (object)(DateTime.Now - timeA).Milliseconds + "ms");
                        break;

                    case "3":
                        List<string> linq = Program.words.ToList<string>();
                        DateTime timeB = DateTime.Now;
                        linq.Sort();
                        Console.WriteLine("Time used to sort: " + (object)(DateTime.Now - timeB).Milliseconds + "ms");
                        break;

                    case "4":
                        Console.WriteLine("There are " + (object)Program.words.Distinct<string>().Count<string>() + " distinct words.");
                        break;

                    case "5":
                        Program.printWords(Program.words.Take<string>(10).ToList<string>());
                        break;

                    case "6":
                        Program.printWords(Program.words.Where<string>((Func<string, bool>)(o => o.ToLower().StartsWith("j"))).ToList<string>());
                        Console.WriteLine("There are " + (object)Program.words.Count<string>((Func<string, bool>)(o => o.ToLower().StartsWith("j"))) + " words that starts with 'j'. ");
                        break;

                    case "7":
                        Program.printWords(Program.words.Where<string>((Func<string, bool>)(o => o.ToLower().EndsWith("d"))).ToList<string>());
                        Console.WriteLine("There are " + (object)Program.words.Count<string>((Func<string, bool>)(o => o.ToLower().EndsWith("d"))) + " words that ends with 'd'. ");
                        break;

                    case "8":
                        Program.printWords(Program.words.Where<string>((Func<string, bool>)(o => o.Length > 4)).ToList<string>());
                        Console.WriteLine("There are " + (object)Program.words.Count<string>((Func<string, bool>)(o => o.Length > 4)) + " words that has more than 4 characters.");
                        break;

                    case "9":
                        Program.printWords(Program.words.Where<string>((Func<string, bool>)(o => o.Length < 3 && o.ToLower().StartsWith("a"))).ToList<string>());
                        Console.WriteLine("There are " + (object)Program.words.Count<string>((Func<string, bool>)(o => o.Length < 3 && o.ToLower().StartsWith("a"))) + " words that has less than 3 characters and start with 'a'. ");
                        break;

                    case "x":
                        flag = false;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid input");
                        break;
                }
                Console.WriteLine();
            }
        }
        private static void Import()
        {
            using (StreamReader reader = new StreamReader("Words.txt"))
            {
                string empty = string.Empty;
                string wordFromTxt;
                while ((wordFromTxt = reader.ReadLine()) != null)
                    Program.words.Add(wordFromTxt);
            }
            Console.WriteLine("Reading Words complete");
            Console.WriteLine("Number of words found: " + (object)Program.words.Count);
        }
        private static string[] bubbleSort(List<string> words)
        {
            string[] array = words.ToArray();
            for (int i = 1; i <= array.Length - 1; ++i)
            {
                for (int i2 = 0; i2 < array.Length - 1; ++i2)
                {
                    if (array[i2 + 1].CompareTo(array[i2]) > 0)
                    {
                        string x = array[i2];
                        array[i2] = array[i2 + 1];
                        array[i2 + 1] = x;
                    }
                }
            }
            return array;
        }
      
        private static void printWords(List<string> words)
        {
            Console.Clear();
            if (words == null)
                return;
            foreach (string word in words)
                Console.WriteLine(word);
        }
    }
}
