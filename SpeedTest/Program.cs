using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SpeedTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load phrases from phrases.txt file
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"phrases.txt");
            string[] phrases = File.ReadAllLines(path);

            Random ranNum = new Random();

            List<string> writenPhrases = new List<string>();

            bool runLoop = true;

            // Rerun test as long as user has not quit
            while(runLoop)
            {
                // Begin output
                Console.WriteLine("When you are ready for the speed test, press any key to start.");
                Console.ReadKey();
                Console.Clear();

                long startTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();


                int i = 0;
                while (i < 4)
                {
                    string inString;
                    int ranPhraseNum = ranNum.Next(phrases.Length);

                    string phrase = phrases[ranPhraseNum];
                    Console.WriteLine(phrase);
                    inString = Console.ReadLine();
                    Console.Clear();

                    if (string.Equals(phrase, inString, StringComparison.OrdinalIgnoreCase))
                    {
                        // Right
                    }
                    else
                    {
                        // Wrong
                    }

                    writenPhrases.Add(inString);

                    i++;
                }

                int totalWords = 0;

                foreach (string phrase in writenPhrases)
                {
                    string[] words = phrase.Split(' ');
                    totalWords += words.Length;
                }

                long timeDiff = DateTimeOffset.UtcNow.ToUnixTimeSeconds() - startTime;
                double timeMins = (double)timeDiff / 60;
                int wpm = (int)(totalWords / timeMins);

                Console.WriteLine("WPM = {0}", wpm);
                Console.WriteLine("Words = {0}", totalWords);
                Console.WriteLine("Total time taken = {0} seconds", timeDiff);
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
