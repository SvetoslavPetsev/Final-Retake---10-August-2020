using System;
using System.Text;

namespace SecretChat
{
    class Program
    {
        static void Main()
        {
            string text = Console.ReadLine();
            string input;
            while ((input = Console.ReadLine())!= "Reveal")
            {
                string[] info = input.Split(":|:");
                string cmd = info[0];
                if (cmd == "InsertSpace")
                {
                    int index = int.Parse(info[1]);
                    text = text.Insert(index, " ");
                    Console.WriteLine(text);
                }
                else if (cmd == "Reverse")
                {
                    string substr = info[1];
                    if (text.Contains(substr))
                    {
                        int index = text.IndexOf(substr);
                        text = text.Remove(index, substr.Length);
                        char[] substrArr = substr.ToCharArray();
                        Array.Reverse(substrArr);
                        string reversed = new string(substrArr);
                        text = text.Insert(text.Length, reversed);
                        Console.WriteLine(text);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (cmd == "ChangeAll")
                {
                    string substr = info[1];
                    string replacement = info[2];

                    if (text.Contains(substr))
                    {
                        text = text.Replace(substr, replacement);
                        Console.WriteLine(text);
                    }
                }
            }
            Console.WriteLine($"You have a new text message: {text}");
        }
    }
}
