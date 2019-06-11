using System;
using System.Collections.Generic;

namespace SpeedTest
{
    class Program
    {
        static void Main(string[] args)
        {

            String[] phrases = new String[]
            {
                "The quick brown mouse jumped over the tall frog.",
                "Quick was the man who had to build the house.",
                "Gone are the days of hardship and paradise.",
                "A journey of a thousand miles begins with a single step.",
                "A house divided against itself cannot stand.",
                "A man who is his own lawyer has a fool for a client.",
                "Abandon all hope ye who enter here.",
                "Absence makes the heart grow fonder.",
                "Jack of All Trades Master of None.",
                "Everything But The Kitchen Sink.",
                "Barking Up The Wrong Tree.",
                "A Fool and His Money are Soon Parted.",
                "What Am I, Chopped Liver?",
                "You Can't Judge a Book By Its Cover",
                "Every Cloud Has a Silver Lining.",
                "You Can't Teach an Old Dog New Tricks.",
                "Birds of a Feather Flock Together."
            };

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
