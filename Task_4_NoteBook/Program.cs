using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task_4_NoteBook
{
    internal class Program
    {
        /// <summary>
        /// Метод, заполняющий сведения о контакте.
        /// </summary>
        /// <returns>Заполненный контакт.</returns>
        static XElement FillPerson()
        {
            Console.Write("ФИО: ");
            XAttribute xAttributePersonName = new XAttribute("name", Console.ReadLine());

            Console.WriteLine("\nАдрес контакта.");

            Console.Write("Улица: ");
            string street = Console.ReadLine();

            Console.Write("Номер дома: ");
            string houseNumber = Console.ReadLine();

            Console.Write("Номер квартиры: ");
            string flatNumber = Console.ReadLine();

            Console.WriteLine("\nНомера телефонов.");

            Console.Write("Мобильный телефон: ");
            string mobilePhone = Console.ReadLine();

            Console.Write("Домашний телефон: ");
            string flatPhone = Console.ReadLine();

            XElement person =
                new XElement("Person",
                    new XElement("Address",
                        new XElement("Street", street),
                        new XElement("HouseNumber", houseNumber),
                        new XElement("FlatNumber", flatNumber)
                    ),
                    new XElement("Phones",
                        new XElement("MobilePhone", mobilePhone),
                        new XElement("FlatPhone", flatPhone)
                    )
                );
            person.Add(xAttributePersonName);

            return person;
        }

        /// <summary>
        /// Метод, выводящий содержимое файла в консоль.
        /// </summary>
        /// <param name="path">Путь к файлу.</param>
        static void PrintPerson(string path)
        {
            string xml = System.IO.File.ReadAllText(path);

            var col = XDocument.Parse(xml)
                               .Descendants("Person")
                               .ToList();

            foreach (var item in col)
            {
                Console.WriteLine($"{item}");
            }

            Console.ReadLine();
        }
        
        static void Main(string[] args)
        {
            string path = "_person.xml";
            FillPerson().Save(path);
            Console.Clear();

            PrintPerson(path);
        }
    }
}
