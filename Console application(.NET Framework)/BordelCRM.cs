namespace Console_application_.NET_Framework_
{
    using System;
    using System.Collections.Generic;

    /// <summary>Приложение CRM для борделя.</summary>
    public class BordelCRM
    {
        /// <summary>Словарь данных этажей.</summary>
        private Dictionary<int, int[]> floors;

        /// <summary>Текущий этаж.</summary>
        private int floor;

        /// <summary>Текущий баланс.</summary>
        private int money = 500;

        /// <summary>Конструктор.</summary>
        public BordelCRM()
        {
            this.floors = new Dictionary<int, int[]>();
            this.floors.Add(1, new int[] { 4, 6 });
            this.floors.Add(2, new int[] { 8, 10 });
            this.floors.Add(3, new int[] { 12, 14 });
            this.floors.Add(4, new int[] { 16, 18 });
            this.floors.Add(5, new int[] { 20, 22 });

            this.floor = 1;

            this.money = 500;
        }

        /// <summary>Запуск модуля.</summary>
        public void Action()
        {
            OutLine($"Ты зашел в пятиэтажное здание");
            this.Do();
            string move;
            while (true) // Бесконечный цикл, не ограниченный итерациями.
            {
                move = Console.ReadLine();

                move = StringConverter(move);
                if (move == "вверх")
                {
                    if (this.floor != 5)
                    {
                        this.floor = Up(this.floor);
                    }
                    else
                    {
                        OutLine("А выше некуда");
                    }
                }
                else if (move == "вниз")
                {
                    if (this.floor != 1)
                    {
                        this.floor = Down(this.floor);
                    }
                    else
                    {
                        OutLine("А ниже некуда");
                    }
                }
                else if (move == "выйти")
                {
                    if (this.floor == 1)
                    {
                        OutLine("До встречи :) ");
                        break;
                    }
                    else
                    {
                        OutLine("С окна спрыгнуть?");
                    }
                }
                else if (move == "казино" && this.floor == 1)
                {
                    OutLine("#######################################");
                    OutLine("Добро пожаловать в казино LO$E MONEY");
                    while(true)
                    {
                        this.money = Casino(this.money);
                        Out("Пойти на выход?(Да/Нет): ");
                        string choiceYesOrNot = Console.ReadLine();
                        choiceYesOrNot = StringConverter(choiceYesOrNot); 
                        if (choiceYesOrNot == "да")
                        {
                            break;
                        }
                    }
                }
                else
                {
                    OutLine("Я не знаю такой команды");
                }

                this.Do();
            }

        }

        /// <summary>Вывод без перевода строки.</summary>
        /// <param name="message">Текст.</param>
        /// <param name="foreground">Цвет текста.</param>
        /// <param name="backfround">Цвет фона.</param>
        private static void Out(string message, ConsoleColor foreground = ConsoleColor.White, ConsoleColor backfround = ConsoleColor.Black)
        {
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = backfround;
            Console.Write(message);
        }

        /// <summary>Вывод с переводом строки.</summary>
        /// <param name="message">Текст.</param>
        /// <param name="foreground">Цвет текста.</param>
        /// <param name="backfround">Цвет фона.</param>
        private static void OutLine(string message, ConsoleColor foreground = ConsoleColor.White, ConsoleColor backfround = ConsoleColor.Black)
        {
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = backfround;
            Console.WriteLine(message);
        }

        /// <summary>Подняться на этаж.</summary>
        /// <param name="floor">текущий этаж.</param>
        /// <returns>Новый этаж.</returns>
        static int Up(int floor)
        {
            floor++;
            return floor;
        }

        /// <summary>Спуститься на этаж.</summary>
        /// <param name="floor">Теукщий этаж.</param>
        /// <returns>Изменённый этаж.</returns>
        static int Down(int floor)
        {
            floor--;
            return floor;
        }

        /// <summary>Сдалать шаг.</summary>
        private void Do()
        {
            OutLine("-------------------------------------------------");
            Out($"Ты на {this.floor} этаже с комнатами ");
            for (int i = 0; i < this.floors[this.floor].Length; i++)
            {
                Out($"{this.floors[this.floor][i]} ");
            }
            OutLine(string.Empty);
            if (this.floor == 1)
            {
                OutLine("(Выйти/Вверх/Казино)");
            }
            else if (this.floor == 5)
            {
                OutLine("(Выйти/Вниз)");
            }
            else
            {
                OutLine("(Выйти/Вверх/Вниз)");
            }

            Out("Что делать будешь: ");
        }

        /// <summary>Рулетка.</summary>
        /// <param name="money">Текущий баланс.</param>
        /// <returns>Новый баланс.</returns>
        static int Casino(int money)
        {
            OutLine($"Баланс: {money}$");
            OutLine(string.Empty);
            Out(0 + " ",ConsoleColor.Green);
            for (int i = 1; i < 37; i++)
            {
                if (i % 2 == 0)
                {
                    Out(i + " ", ConsoleColor.Black, ConsoleColor.Gray);
                }

                else
                {
                    Out(i + " ",ConsoleColor.Red);
                }
            }

            Out(string.Empty);
            OutLine(string.Empty);
            Out("Введи размер ставки($): ");
            
            int bet = Convert.ToInt32(Console.ReadLine());
            if (bet <= money)
            {
                money = money - bet;
                Out("(Красное/Чёрное/Чётное/Нечётное/Диапазон(1-18;19-36)/Число): ");
                string play = Console.ReadLine();
                play = StringConverter(play);

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
                    Out("(первый/второй): ");
                    string choiceDiapason = Console.ReadLine();
                    choiceDiapason = StringConverter(choiceDiapason);

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
                        OutLine("Нет такого диапазона");
                    }
                }
                else if (play == "число")
                {
                    Out("Введи число: ");
                    int choiceNumber = Convert.ToInt32(Console.ReadLine());
                    if (choiceNumber == number)
                    {
                        money += (bet * 36) + bet;
                    }
                }

                if (number == 0)
                {
                    Out("Выпавшее число: ");
                    OutLine(number.ToString(),ConsoleColor.Green);
                }
                else if (number % 2 == 0)
                {
                    Out("Выпавшее число: ");
                    OutLine(number.ToString(),ConsoleColor.Black,ConsoleColor.Gray);
                }
                else if (number % 2 != 0)
                {
                    Out("Выпавшее число: ");
                    OutLine(number.ToString(), ConsoleColor.Red);
                }

                OutLine($"Баланс: {money}$");

            }
            else
            {
                OutLine("У тебя нет таких денег :(");
            }

            return money;
        }

        /// <summary>Удаление пробелов и изменение строки на нижний регистр.</summary>  
        static string StringConverter(string title)
        {
            title = title.Trim();
            title = title.ToLower();
            string title2 = title;
            
            return title2;

        }
        
    }
}