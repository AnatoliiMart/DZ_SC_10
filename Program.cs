using System.Drawing;
using System;

namespace DZ_SC_10
{
    internal class Program
    {
        delegate string? RainbowRGB(string? color);

        static RainbowRGB GetRGB                = (string? color) =>
        {
            
            int r;
            int g;
            int b;
            if (color != null)
                switch (color.ToLower())
                {
                    case "red":
                        r = 255;
                        g = 0;
                        b = 0;
                        return r.ToString() + " , " + g.ToString() + " , " + b.ToString();
                    case "orange":
                        r = 255;
                        g = 127;
                        b = 0;
                        return r.ToString() + " , " + g.ToString() + " , " + b.ToString();
                    case "yellow":
                        r = 255;
                        g = 255;
                        b = 0;
                        return r.ToString() + " , " + g.ToString() + " , " + b.ToString();
                    case "green":
                        r = 0;
                        g = 255;
                        b = 0;
                        return r.ToString() + " , " + g.ToString() + " , " + b.ToString();
                    case "cyan":
                        r = 0;
                        g = 0;
                        b = 255;
                        return r.ToString() + " , " + g.ToString() + " , " + b.ToString();
                    case "indigo":
                        r = 46;
                        g = 43;
                        b = 95;
                        return r.ToString() + " , " + g.ToString() + " , " + b.ToString();
                    case "violet":
                        r = 139;
                        g = 0;
                        b = 255;
                        return r.ToString() + " , " + g.ToString() + " , " + b.ToString();
                    default:
                        return null;
                }
            return null;
        };

        static Func<int[], int> MultipleOfSeven = (int[] a)       =>
        {
            int count = 0;
            foreach (int i in a)
                if (i % 7 == 0)
                    count++;
            return count;
        };

        static Func<int[], int> PositiveCount   = (int[] a)       =>
        {
            int count = 0;
            foreach (int i in a)
                if (i >= 0)
                    count++;
            return count;
        };

        static Action<int[]>    UniqueNegative  = (int[] a)       =>
        {
            Console.Write("All unique negative numbers in array:\t\t");
            bool found;
            for (int i = 0; i < a.Length; i++)
            {
                found = false;
                for (int j = 0; j < a.Length; j++)
                {
                    if (i != j && a[i] == a[j])
                    {
                        found = true;
                        break;
                    }
                }
                if (!found && a[i] < 0) Console.Write(a[i] + " ");
            }
            Console.WriteLine();

        };

        static Action<string>   GivenWord       = (string word)   =>
        {
            word = word.ToLower();
            string[] words = word.Split(' ');
            Console.Write("Enter the word to find:\t");
            string? keyWord = Console.ReadLine();
            int ? count = 0;
            foreach (var item in words)
            {
                if(item == keyWord)
                    count++;
            }
            Console.WriteLine($"In text is {count} word(s) \"{keyWord}\"");
        };

        static void Main(string[] args)
        {
           // Ex1();
           // Ex2();
           Ex3_4_5_6();
        }
        static void Ex1()
        {
            Console.WriteLine("Enter the color of rainbow:");
            string? str = Console.ReadLine();
            Console.WriteLine("RGB code of entered color:\t" + GetRGB(str));
        }

        static void Ex2()
        {
            List<Item> items = new List<Item>();

            Briefcase briefcase = new("Red", "Adidas", "Polyester", 5, 20, items);

            Console.WriteLine(briefcase.ToString());

            try
            {
                briefcase.PutItemInBriefcase(new Item());
                briefcase.PutItemInBriefcase(new Item());
                briefcase.PutItemInBriefcase(new Item());
                briefcase.PutItemInBriefcase(new Item());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            foreach (var item in items)
            {
                Console.WriteLine(item.ToString());
                Console.WriteLine();

            }

            Console.WriteLine(briefcase.PrintInfo());
        }
        static void Ex3_4_5_6()
        {
            int[] a = { -1, -2, -3, -3, -4, -5, -6, -7, -7, 8, 9, 10, 10, 11, 12, 13, 13, 14, 15, -15 };
            Console.WriteLine("Elements of array what is multiple of 7 :\t" + MultipleOfSeven(a));

            Console.WriteLine("Amount of positive elements of array:\t\t" + PositiveCount(a));

            UniqueNegative(a);

            string s = "Hello world hello child hello city city city";
            GivenWord(s);
        }
        
    }
}