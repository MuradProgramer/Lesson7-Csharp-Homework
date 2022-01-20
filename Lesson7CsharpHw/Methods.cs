using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    class Method 
    {
        public static string ToPassword(string txt, string username)
        {
            string st = string.Empty;
            int count = 1;
            Console.Write(txt);
            while (true)
            {
                var key = Console.ReadKey();
                Console.Clear();
                Console.WriteLine($"\n\n\n\t\t\u25ba ENTER USERNAME: {username}");
                Console.Write(txt);
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    return st;
                }
                char ckey = key.KeyChar;
                st += ckey;
                for (int i = 0; i < count; i++)
                    Console.Write("*");
                count++;
            }

        }

        public static int Selecting(string[] menu)
        {

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write($"\n\n\n\t\t{menu[0]}");
            Console.ResetColor();

            for (int i = 1; i < menu.Length; i++)
            {
                Console.Write($"\t\t{menu[i]}");
            }
            int ind = 0;


            while (true)
            {
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                {
                    return -1;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    if (ind + 1 == menu.Length)
                    {
                        Console.Clear();
                        Console.ResetColor();
                        ind = 0;
                        Console.WriteLine("\n\n");
                        for (int i = 0; i < menu.Length; i++)
                        {
                            if (i == ind)
                            {
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write($"\t\t{menu[i]}");
                                Console.ResetColor();
                                continue;
                            }
                            Console.Write($"\t\t{menu[i]}");
                        }
                        Thread.Sleep(60);
                        continue;
                    }

                    else
                    {
                        Console.Clear();
                        Console.ResetColor();
                        Console.WriteLine("\n\n");
                        ind++;
                        for (int i = 0; i < menu.Length; i++)
                        {
                            if (i == ind)
                            {
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write($"\t\t{menu[i]}");
                                Console.ResetColor();
                                continue;
                            }
                            Console.Write($"\t\t{menu[i]}");
                        }
                        Thread.Sleep(60);
                    }
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    if (ind - 1 < 0)
                    {
                        Console.Clear();
                        Console.ResetColor();
                        ind = menu.Length - 1;
                        Console.WriteLine("\n\n");
                        for (int i = 0; i < menu.Length; i++)
                        {
                            if (i == ind)
                            {
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write($"\t\t{menu[i]}");
                                Console.ResetColor();
                                continue;
                            }
                            Console.Write($"\t\t{menu[i]}");
                        }
                        Thread.Sleep(60);
                        continue;
                    }

                    else
                    {
                        Console.Clear();
                        Console.ResetColor();
                        ind--;
                        Console.WriteLine("\n\n");
                        for (int i = 0; i < menu.Length; i++)
                        {
                            if (i == ind)
                            {
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write($"\t\t{menu[i]}");
                                Console.ResetColor();
                                continue;
                            }
                            Console.Write($"\t\t{menu[i]}");
                        }
                        Thread.Sleep(60);
                    }
                }
                else
                    continue;
            }
            return ind;
        }
    }
}
