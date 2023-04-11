using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modul_05
{
    internal class Задание_1
    {
        /*Задание 1
        Ранее в одном из практических заданий вы создавали класс «Журнал».
        Добавьте к уже созданному классу информацию о количестве сотрудников.
        Выполните перегрузку 
        + (для увеличения количества сотрудников на указанную величину), 
        — (для уменьшения количества сотрудников на указанную величину), 
        == (проверка на равенство количества сотрудников), 
        < и > (проверка на меньше или больше количества сотрудников), 
        != и Equals. Используйте механизм свойств для полей класса.*/
        class Journal
        {
            // название журнала
            private string name;
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            // год основания
            private int year;
            public int Year
            {
                get { return year; }
                set { year = value; }
            }
            // описание журнала
            private string description;
            public string Description
            {
                get { return description; }
                set { description = value; }
            }
            // контактный телефон
            private string phone;
            public string Phone
            {
                get { return phone; }
                set { phone = value; }
            }
            // контактный e-mail
            private string email;
            public string Email
            {
                get { return email; }
                set { email = value; }
            }
            // количество сотрудников
            private int employeesCount;
            public int EmployeesCount
            {
                get { return employeesCount; }
                set { employeesCount = value; }
            }
            public void PrintJournal()
            {
                Console.WriteLine("Журнал:        {0}", Name);
                Console.WriteLine("Год основания: {0}", Year);
                Console.WriteLine("Описание:      {0}", Description);
                Console.WriteLine("Телефон:       {0}", Phone);
                Console.WriteLine("Email:         {0}", Email);
                Console.WriteLine("Кол-во сотрудников: {0}\n", EmployeesCount);
            }
            // ввода данных
            public void InputJournal()
            {
                Console.Write("Введите название журнала: ");
                Name = Console.ReadLine();

                Console.Write("Введите год основания: ");
                Year = int.Parse(Console.ReadLine());

                Console.Write("Введите описание журнала: ");
                Description = Console.ReadLine();

                Console.Write("Введите контактный телефон: ");
                Phone = Console.ReadLine();

                Console.Write("Введите контактный email: ");
                Email = Console.ReadLine();

                Console.Write("Введите количество сотрудников: ");
                EmployeesCount = int.Parse(Console.ReadLine());
                Console.WriteLine();
            }
            // для увеличения количества сотрудников на указанную величину
            public static Journal operator +(Journal journal, int employeesToAdd)
            {
                journal.EmployeesCount += employeesToAdd;
                return journal;
            }
            // для уменьшения количества сотрудников на указанную величину
            public static Journal operator -(Journal journal, int employeesToRemove)
            {
                journal.EmployeesCount -= employeesToRemove;
                return journal;
            }
            // проверка на равенство количества сотрудников
            public static bool operator ==(Journal journal1, Journal journal2)
            {
                return journal1.EmployeesCount == journal2.EmployeesCount;
            }
            public static bool operator !=(Journal journal1, Journal journal2)
            {
                return journal1.EmployeesCount != journal2.EmployeesCount;
            }
            // проверка на меньше или больше количества сотрудников
            public static bool operator <(Journal journal1, Journal journal2)
            {
                return journal1.EmployeesCount < journal2.EmployeesCount;
            }
            public static bool operator >(Journal journal1, Journal journal2)
            {
                return journal1.EmployeesCount > journal2.EmployeesCount;
            }
            //
            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                    return false;

                Journal journal = (Journal)obj;
                return EmployeesCount == journal.EmployeesCount;
            }
            public override int GetHashCode()
            {
                return EmployeesCount;
            }
        }
        static void Main(string[] args)
        {
            Journal journal1 = new Journal();
            Console.WriteLine("Введите данные для журнала 1");
            journal1.InputJournal();
            
            Journal journal2 = new Journal();
            Console.WriteLine("Введите данные для журнала 2");
            journal2.InputJournal();
            Console.Clear(); // очищаем консоль

            Console.WriteLine("Информация о журналах:");
            journal1.PrintJournal();
            Console.WriteLine();
            journal2.PrintJournal();

            Console.WriteLine("\nДобавляем 5 сотрудников в журнал 1");
            journal1 += 5;
            journal1.PrintJournal();

            Console.WriteLine("\nУбираем 3 сотрудников из журнала 2");
            journal2 -= 3;
            journal2.PrintJournal();

            Console.WriteLine("\nСравниваем количество сотрудников в журналах:");
            if (journal1 == journal2) {
                Console.WriteLine("Количество сотрудников в обоих журналах равно");
            }
            else if (journal1 < journal2) {
                Console.WriteLine("Журнал 1 имеет меньше сотрудников, чем журнал 2");
            }
            else { Console.WriteLine("Журнал 1 имеет больше сотрудников, чем журнал 2"); 
            }
        }
    }
}
