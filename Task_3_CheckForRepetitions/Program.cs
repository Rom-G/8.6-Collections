using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Task_3_CheckForRepetitions
{
    internal class Program
    {
        /// <summary>
        /// Метод, получающий число от пользователя.
        /// </summary>
        /// <returns>Данные введённые пользователем (число или null).</returns>
        static Nullable<int> GetNumber()
        {
            Console.Write("\nВведите число: ");
            string input = Console.ReadLine();
            if (input == string.Empty)
            {
                return null;
            }
            else if (int.TryParse(input, out int number)) 
            {
                int? numberNullAllow = number;
                return numberNullAllow;
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Требуется число.");
                return GetNumber();
            }
        }
        
        /// <summary>
        /// Метод, создающий коллекцию и добавляющий в неё числа.
        /// </summary>
        static void ManageCollection()
        {
            HashSet<int> set = [];
            int? numberOrNull;
            int number;
            do
            {
                numberOrNull = GetNumber();
                if (!numberOrNull.HasValue)
                {
                    continue;
                }

                number = numberOrNull.Value;

                if (set.Add(number))
                {
                    Console.WriteLine("Число успешно сохранено.");
                }
                else
                {
                    Console.WriteLine("Число уже вводилось ранее.");
                }
            } while (numberOrNull.HasValue);

            PrintSet(set);
        }

        /// <summary>
        /// Метод, выводящий коллекцию чисел на экран.
        /// </summary>
        /// <param name="set">Коллекция чисел.</param>
        static void PrintSet(HashSet<int> set)
        {
            Console.Clear();
            Console.Write("Итоговое множество: ");
            foreach (var e in set)
            {
                Console.Write($"{e} ");
            }
            
            Console.WriteLine($"\n\nКоличество элементов в коллекции - {set.Count}.");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте!" +
                "\nСоздание множества не повторяющихся чисел." +
                "\nЧтобы закончить ввод чисел, нажмите Enter");

            ManageCollection();

            Console.WriteLine("Нажмите Enter, чтобы завершить программу.");
            Console.ReadLine();
            Console.WriteLine("До свидания!");
            Thread.Sleep(500);
        }
    }
}
