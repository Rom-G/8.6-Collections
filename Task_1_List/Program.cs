using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1_List
{
    internal class Program
    {
        /// <summary>
        /// Метод, заполняющий коллекцию случайными числами от 0 до 100.
        /// </summary>
        /// <param name="list">Коллекция для заполнения числами</param>
        /// <param name="count">Количество чисел для добавления.</param>
        /// <returns>Коллекция заполненная числами.</returns>
        static List<int> FillList(List<int> list, int count)
        {
            Random rnd = new Random();
            for (int i = 0; i < count; i++)
            {
                list.Add(rnd.Next(101));
            }

            return list;
        }

        /// <summary>
        /// Метод, выводящий коллекцию чисел на экран.
        /// </summary>
        /// <param name="list">Коллекция чисел.</param>
        static void PrintList(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"\tЭлемент {i}: {list[i]}");
            }
            Console.WriteLine($"Количество элементов в листе - {list.Count}.");
        }

        /// <summary>
        /// Метод, удаляющий из коллекции числа больше 25, но меньше 50.
        /// </summary>
        /// <param name="list">Коллекция чисел.</param>
        /// <returns>Коллекция без чисел больше 25, но меньше 50.</returns>
        static List<int> DeleteRange(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] > 25 && list[i] < 50)
                {
                    list.RemoveAt(i);
                    i--;
                }
            }

            return list;
        }

        /// <summary>
        /// Метод, выполняющий операции с коллекцией.
        /// </summary>
        static void ManageList()
        {
            List<int> list = new List<int>(100);

            list = FillList(list, 100);
            Console.WriteLine("Коллекция заполненная случайными числами от 0 до 100:");
            PrintList(list);
            Console.ReadLine(); Console.Clear();

            list = DeleteRange(list);
            Console.WriteLine("Числа больше 25, но меньше 50 удалены:");
            PrintList(list);
        }

        static void Main(string[] args)
        {
            ManageList();
            Console.ReadLine();
        }
    }
}
