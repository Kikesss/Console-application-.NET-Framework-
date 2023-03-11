using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_application_.NET_Framework_
{
    internal class Program
    {
        static void first_floor()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Ты на первом этаже, на нём пять комнат (12) (13) (14) (15) (16)");
                Console.Write("Куда пойдешь(Вверх, Вниз, Выйти): ");
                string step = Console.ReadLine();
                if (step == "Вверх" || step == "вверх")
                {
                    second_floor();
                    break;
                }

                if (step == "Вниз" || step == "вниз")
                {
                    Console.WriteLine("А ниже некуда");
                }

                if (step == "Выйти" || step == "выйти")
                {
                    Console.WriteLine("До встречи :3 ");
                    break;
                }

                else
                {
                    Console.WriteLine("Я не знаю такой команды :( ");
                }
            }
        }

        static void second_floor()
        {

            Console.WriteLine("Ты на втором этаже, на нём четыре комнаты (17) (18) (19) (20)");
            Console.Write("Куда пойдешь(Вверх, Вниз): ");
            string step = Console.ReadLine();
            if (step == "Вверх" || step == "вверх")
            {
                third_floor();
            }

            if (step == "Вниз" || step == "вниз")
            {
                first_floor();
            }
            
            else
            {
                Console.WriteLine("Я не знаю такой команды :( ");
            }
        }

        static void third_floor()
        {

            Console.WriteLine("Ты на третьем этаже, на нём три комнаты (21) (22) (23)");
            Console.Write("Куда пойдешь(Вверх, Вниз): ");
            string step = Console.ReadLine();
            if (step == "Вверх" || step == "вверх")
            {
                fourth_floor();
            }

            if (step == "Вниз" || step == "вниз")
            {
                second_floor();
            }
            else
            {
                Console.WriteLine("Я не знаю такой команды :( ");
            }
        }

        static void fourth_floor()
        {
            Console.WriteLine("Ты на четвертом этаже, на нём две комнаты (24) (25)");
            Console.Write("Куда пойдешь(Вверх, Вниз): ");
            string step = Console.ReadLine();
            if (step == "Вверх" || step == "вверх")
            {
                fifth_floor();
            }

            if (step == "Вниз" || step == "вниз")
            {
                third_floor();
            }
            else
            {
                Console.WriteLine("Я не знаю такой команды :( ");
            }
        }

        static void fifth_floor()
        {

            Console.WriteLine("Ты на пятом этаже, на нём одна комната (26)");
            Console.Write("Куда пойдешь(Вверх, Вниз): ");
            string step = Console.ReadLine();

            while (step == "Вверх" || step == "вверх")
            {
                Console.WriteLine("А выше некуда");
                Console.WriteLine("Ты на пятом этаже, на нём одна комната (26)");
                Console.Write("Куда пойдешь(Вверх, Вниз): ");
                step = Console.ReadLine();

            }

            if (step == "Вниз" || step == "вниз")
            {
               fourth_floor();
            }
            else
            {
               Console.WriteLine("Я не знаю такой команды :( ");
            }
            
        }

        
        
        static void Main(string[] args)
        {
            Console.WriteLine("Ты зашел в пятиэтажное здание");
            first_floor();
        }

        

        

        

        

        
    }
}
