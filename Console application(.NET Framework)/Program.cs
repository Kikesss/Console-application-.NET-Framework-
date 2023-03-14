using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_application_.NET_Framework_
{
    internal class Program
    {
        
        
        static void Main(string[] args)
        {
            Dictionary<int, int[]> floors = new Dictionary<int, int[]>();
            floors.Add(1, new int[] { 4, 6 });
            floors.Add(2, new int[] { 8, 10 });
            floors.Add(3, new int[] { 12, 14 });
            floors.Add(4, new int[] { 16, 18 });
            floors.Add(5, new int[] { 20, 22 });

            int floor = 1;
            Console.WriteLine($"Ты зашел в пятиэтажное здание");
            Do(floor, floors);
            string move;
            
            



            for (int i = 0; i < 100; i++)
            {
                move = Console.ReadLine();
                
                if (move == "Вверх" || move == "вверх")
                {
                    if (floor != 5)
                    {
                        floor = Up(floor);
                    }
                    else
                    {
                        Console.WriteLine("А выше некуда");
                    }
                    Do(floor, floors);
                }

                else if (move == "Вниз" || move == "вниз")
                {
                    if (floor != 1)
                    {
                        floor = Down(floor);
                    }
                    else
                    {
                        Console.WriteLine("А ниже некуда");
                    }
                    Do(floor, floors);
                }

                else if (move == "Выйти" || move == "выйти")
                {
                    if (floor == 1)
                    {
                        Console.WriteLine("До встречи :) ");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("С окна спрыгнуть?");
                    }
                    Do(floor, floors);
                }

                else if (move == "казино")
                {
                    Console.WriteLine("#######################################");
                    Console.WriteLine("Добро пожаловать в казино LO$E MONEY");
                    for (; ; )
                    {
                        Casino();
                        Console.Write("Пойти на выход?(Да/Нет): ");
                        string choiceYesOrNot = Console.ReadLine();
                        if (choiceYesOrNot == "да")
                        {
                            break;
                        }

                        
                    }

                }

                else
                {
                    Console.WriteLine("Я не знаю такой команды");
                    Do(floor, floors);
                }
            }


        }

        static int Up(int floor)
        {
            floor++;
            return floor;
        }

        static int Down(int floor)
        {
            floor--;
            return floor;
        }
        static void Do(int floor, Dictionary<int, int[]> floors)
        {
            Console.WriteLine("-------------------------------------------------");
            Console.Write($"Ты на {floor} этаже с комнатами ");
            for (int i = 0; i < floors[floor].Length; i++)
            {
                Console.Write($"{floors[floor][i]} ");
            }
            Console.WriteLine();
            if (floor == 1)
            {
                Console.WriteLine("(Выйти/Вверх/Казино)");
            }
            else if (floor == 5)
            {
                Console.WriteLine("(Выйти/Вниз)");
            }
            else
            {
                Console.WriteLine("(Выйти/Вверх/Вниз)");
            }

            Console.Write("Что делать будешь: ");
            
        }

        static int Casino()
        {
            int money = 500;
            
            Console.WriteLine($"Баланс: {money}$");

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(0 + " ");
            for (int i = 1; i < 37; i++)
            {
                if (i % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(i + " ");
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(i + " ");
                }
            }

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Введи размер ставки($): ");
            int bet = Convert.ToInt32(Console.ReadLine());
            if (bet <= money)
            {
                money = money - bet;
                Console.Write("(Красное/Чёрное/Чётное/Нечётное/Диапазон(1-18;19-36)/Число): ");
                string play = Console.ReadLine();

                Random random = new Random();
                int number = random.Next(0, 36);

                if (play == "красное" || play == "нечетное")
                {
                    if (number % 2 != 0)
                    {
                        money += (bet * 2) + bet;
                    }

                    else
                    {
                        bet = 0;
                    }
                }
                else if (play == "черное" || play == "четное")
                {
                    if (number % 2 == 0)
                    {
                        money += (bet * 2) + bet;
                    }

                    else
                    {
                        bet = 0;
                    }
                }
                else if (play == "диапазон")
                {
                    Console.Write("(первый/второй): ");
                    string choiceDiapason = Console.ReadLine();
                    if (choiceDiapason == "первый")
                    {
                        if (number <= 18)
                        {
                            money += (bet * 2) + bet;
                        }
                        else
                        {
                            bet = 0;
                        }

                    }

                    else if (choiceDiapason == "второй")
                    {
                        if (number > 18)
                        {
                            money += (bet * 2) + bet;
                        }
                        else
                        {
                            bet = 0;
                        }
                    }

                    else
                    {
                        Console.WriteLine("Нет такого диапазона");
                    }
                }
                else if (play == "число")
                {
                    Console.Write("Введи число: ");
                    int choiceNumber = Convert.ToInt32(Console.ReadLine());
                    if (choiceNumber == number)
                    {
                        money += (bet * 36) + bet;
                    }
                }

                if (number == 0)
                {
                    Console.Write("Выпавшее число: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(number);
                }
                else if (number % 2 == 0)
                {
                    Console.Write("Выпавшее число: ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine(number);
                }
                else if (number % 2 != 0)
                {
                    Console.Write("Выпавшее число: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(number);
                }
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine($"Баланс: {money}$");

            }

            else
            {
                Console.WriteLine("У тебя нет таких денег :(");
            }

            return money;

        }


    }
}











