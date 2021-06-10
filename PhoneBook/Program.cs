using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBook
{
    class Program
    {
        static void Main()
        {
            //  создаём список с типом данных Contact
            var phoneBook = new List<Contact>
            {
                // добавляем контакты
                new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"),
                new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"),
                new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"),
                new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"),
                new Contact("Сергей", "Брин", 799900000013, "serg@example.com"),
                new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com")
            };

            while (true)
            {
                Console.WriteLine("Введите номер страницы для отображения ее содержимого:");
                var keyChar = Console.ReadKey().KeyChar; // получаем символ с консоли

                Console.WriteLine();

                if (!Char.IsDigit(keyChar))
                {
                    Console.WriteLine("Ошибка ввода: введите число");
                }
                else
                {
                    int pageNumber = (int)Char.GetNumericValue(keyChar);

                    //   проверим, что ввели существующий номер страницы
                    if (pageNumber < 1 || pageNumber > 3)
                    {
                        Console.WriteLine($"Ошибка ввода: страницы {keyChar} не существует");
                    }
                    else
                    {
                        // сортируем контакты телефонной книги сперва по имени, а затем по фамилии
                        var sortedPhonebook = phoneBook.OrderBy(pbook => pbook.Name).ThenBy(pbook => pbook.LastName);
                        var page = sortedPhonebook.Skip((pageNumber - 1) * 2).Take(2);

                        // вывод результата на консоль
                        foreach (var contact in page)
                            Console.WriteLine(contact.Name + " " + contact.LastName + ": " + contact.PhoneNumber);
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
