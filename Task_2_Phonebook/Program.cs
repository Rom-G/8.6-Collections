using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_2_Phonebook
{
    internal class Program
    {
        /// <summary>
        /// Метод, запрашивающий номер телефона и имя контакта.
        /// </summary>
        /// <returns>Телефон и имя контакта.</returns>
        static KeyValuePair<string, string> GetData()
        {
            Console.Write("\nВведите номер телефона: ");
            string phoneNumber = Console.ReadLine();

            if (phoneNumber == string.Empty)
            {
                return new KeyValuePair<string, string>(string.Empty, string.Empty);
            }

            Console.Write("Введите имя контакта: ");
            string name = Console.ReadLine();

            return new KeyValuePair<string, string>(phoneNumber, name);
        }

        /// <summary>
        /// Метод, заполняющий телефоную книгу.
        /// </summary>
        /// <returns>Телефонная книга с введёнными контактами.</returns>
        static Dictionary<string, string> FillPhoneBook()
        {
            Dictionary<string, string> phoneBook = [];
            bool addNext = true;

            do
            {
                KeyValuePair<string, string> contact = GetData();
                if (contact.Key != string.Empty)
                {
                    bool alreadyAdded = !phoneBook.TryAdd(contact.Key, contact.Value);
                    if (alreadyAdded)
                    {
                        Console.WriteLine("Контакт с данным номером уже добавлен.");
                    }
                }
                else
                {
                    addNext = false;
                }
            } while (addNext);

            return phoneBook;
        }

        /// <summary>
        /// Метод, осуществляющий поиск имени контакта по номеру телефона.
        /// </summary>
        /// <param name="phoneNumber">Номер телефона.</param>
        /// <param name="phoneBook">Телефонная книга.</param>
        /// <returns>Имя контакта.</returns>
        static string SearchName(string phoneNumber, Dictionary<string, string> phoneBook)
        {
            bool noResult = !phoneBook.TryGetValue(phoneNumber, out string name);

            if (noResult)
            {
                return string.Empty;
            }

            return name;
        }

        /// <summary>
        /// Метод, управляющий телефонной книгой.
        /// </summary>
        static void ManagePhoneBook()
        {
            Console.WriteLine("Заполните телефонную книгу контактами.");
            Dictionary<string, string> phoneBook = FillPhoneBook();
            Console.Clear();

            Console.WriteLine("Поиск владельца по номеру телефона.");
            char search;
            do
            {
                Console.Write("Введите номер: ");
                string phoneNumber = Console.ReadLine();
                string requiredName = SearchName(phoneNumber, phoneBook);

                if (requiredName == string.Empty)
                {
                    Console.WriteLine("Указанный номер телефона не зарегистрирован.");
                }
                else
                {
                    Console.WriteLine($"Номер телефона {phoneNumber} принадлежит абоненту {requiredName}.");
                }

                Console.WriteLine("Повторить поиск? (д/н)");
                search = Console.ReadKey(true).KeyChar;
            } while (char.ToLower(search) == 'д' || char.ToLower(search) == 'l');
        }

        static void Main(string[] args)
        {
            ManagePhoneBook();
            Console.WriteLine("До свидания!");
            Thread.Sleep(500);
        }
    }
}
