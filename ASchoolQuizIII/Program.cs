using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ASchoolQuizIII
{
    class Program
    {
        static void Main(string[] args)
        {
            var choice = "y";
            while (choice == "Y" || choice == "y")
            {
                string hardniessLevel = " For Trial Tests Press 1\n For Real Tests Press 2\n";
                Console.WriteLine(hardniessLevel);
                int hardniessLevelSelection = int.Parse(Console.ReadLine());
                if (hardniessLevelSelection == 1)
                    Execute(false);
                else if (hardniessLevelSelection == 2)
                    Execute(true);
                Console.WriteLine();
                Console.WriteLine("Press Y or y for for another selection");
                choice = Console.ReadLine();
            }
        }

        static void Execute(bool isHard)
        {
            int[] items = new int[100];
            int value;
            int arraySize;

            StreamReader sr = isHard ? new StreamReader("input_hard.txt") : new StreamReader("input_easy.txt");
            Console.SetIn(sr);

            int ncases;
            ncases = int.Parse(Console.ReadLine());
            bool[] results = new bool[ncases];
            for (int i = 0; i < ncases; i++)
            {
                string s = Console.ReadLine();
                if (string.IsNullOrEmpty(s))
                { i--; continue; }
                string[] arr = s.Split(' ');
                arraySize = int.Parse(arr[0]);
                value = int.Parse(arr[1]);

                //items
                s = Console.ReadLine();
                arr = s.Split(' ');
                for (int j = 0; j < arraySize; j++)
                    items[j] = int.Parse(arr[j]);

                results[i] = ASchoolQuizIII.SchoolQuiz(items, arraySize, value);
            }
            sr.Close();
            sr = isHard ? new StreamReader("output_hard.txt") : new StreamReader("output_easy.txt");
            Console.SetIn(sr);
            int wrongAnswer = 0;
            for (int i = 0; i < ncases; i++)
            {
                string s = Console.ReadLine();
                char[] delim = new char[2];
                delim[0] = ' ';
                delim[0] = '\t';
                string[] split = s.Split(delim);
                string answer = split[split.Length - 1];
                bool correctAnswer = false;
                if (answer == "yes")
                    correctAnswer = true;

                if (results[i] != correctAnswer)
                {
                    wrongAnswer++;
                    Console.WriteLine("wrong answer at case " + (i + 1) + " expected = " + correctAnswer + " received = " + results[i]);
                }
            }
            if (wrongAnswer == 0)
                Console.WriteLine("Congratulations!");
            else
                Console.WriteLine(wrongAnswer + " wrong answer out of " + ncases + " case(s) with percent " + (ncases - (double)wrongAnswer) * 100 / ncases + "% correct");
        }

    }
}