using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace markov
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var scanner = new Scanner("Star Trek TOS Plot Summaries from Eric W Weisstein.txt");
            var mapper = new Mapper();

            int i = 0;
            while (!scanner.IsEnd())
            {
                mapper.Add(scanner.Next());
            }

            string word = "";
            int j = 0;
            do{
                var b = j == 0 ? mapper.MaxWord() : mapper.MaxWord(word);
                word = b.Second + "-" + b.Suffix;
                Console.Write(b.First + " ");
            } while (j ++ < 50);
            Console.Read();
        }
    }
}
