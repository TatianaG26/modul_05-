using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modul_05
{
    internal class Задание_2
    {
        /*Задание 2
        Ранее в одном из практических заданий вы создавали класс «Магазин». 
        Добавьте к уже созданному классу информацию о площади магазина. 
        Выполните перегрузку 
        + (для увеличения площади магазина на указанную величину), 
        — (для уменьшения площади магазина на указанную величину), 
        == (проверка на равенство площадей магазинов), 
        < и > (проверка на меньше или больше площади магазина), 
        != и Equals. Используйте механизм свойств для полей класса.*/
        class Shop
        {
            // название магазина
            private string name;
            public string Name { get => name; set => name = value; }
            // адрес магазина
            private string address;
            public string Address { get => address; set => address = value; }
            // описание профиля магазина
            private string profileDescription;
            public string ProfileDescription { get => profileDescription; set => profileDescription = value; }
            // контактный телефон
            private string phoneNumber;
            public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
            // контактный e-mail
            private string email;
            public string Email { get => email; set => email = value; }
            // площади магазина
            private double area;
            public double Area { get => area; set => area = value; }

            public Shop(string name, string address, string profileDescription, string phoneNumber, string email, double area)
            {
                this.name = name;
                this.address = address;
                this.profileDescription = profileDescription;
                this.phoneNumber = phoneNumber;
                this.email = email;
                this.area = area;
            }
            public Shop() { } // пустой конструктор для удобства создания объектов без параметров
            // ввода данных
            public void Input()
            {
                Console.Write("Введите название магазина: ");
                Name = Console.ReadLine();

                Console.Write("Введите адрес магазина: ");
                Address = Console.ReadLine();

                Console.Write("Введите описание магазина: ");
                ProfileDescription = Console.ReadLine();

                Console.Write("Введите контактный телефон: ");
                PhoneNumber = Console.ReadLine();

                Console.Write("Введите контактный e-mail: ");
                Email = Console.ReadLine();

                Console.Write("Введите площадь магазина: ");
                Area = double.Parse(Console.ReadLine());
                Console.WriteLine();
            }
            // вывода данных
            public void Output()
            {
                Console.WriteLine("Название магазина:  {0}", Name);
                Console.WriteLine("Адрес магазина:     {0}", Address);
                Console.WriteLine("Описание магазина:  {0}", ProfileDescription);
                Console.WriteLine("Контактный телефон: {0}", PhoneNumber);
                Console.WriteLine("Контактный e-mail:  {0}", Email);
                Console.WriteLine("Площадь магазина:   {0}\n", Area);
            }
            // == (проверка на равенство площадей магазинов),
            public static bool operator ==(Shop s1, Shop s2)
            {
                return s1.Area == s2.Area;
            }
            public static bool operator !=(Shop s1, Shop s2)
            {
                return s1.Area != s2.Area;
            }
            // перегрузка метода Equals
            public override bool Equals(object obj)
            {
                if (obj == null || this.GetType() != obj.GetType())
                {
                    return false;
                }
                Shop s = (Shop)obj;
                return this.Area == s.Area;
            }
            // перегрузка метода GetHashCode
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
            // проверка на меньше или больше площади магазина
            public static bool operator <(Shop s1, Shop s2) // перегрузка оператора <
            {
                return s1.Area < s2.Area;
            }
            public static bool operator >(Shop s1, Shop s2) // перегрузка оператора >
            {
                return s1.Area > s2.Area;
            }
            // + для увеличения площади магазина на указанную величину
            public static Shop operator +(Shop s, double addArea) // перегрузка оператора +
            {
                return new Shop(s.Name, s.Address, s.ProfileDescription, s.PhoneNumber, s.Email, s.Area + addArea);
            }
            // - для уменьшения площади магазина на указанную величину
            public static Shop operator -(Shop s, double subArea) // перегрузка оператора -
            {
                return new Shop(s.Name, s.Address, s.ProfileDescription, s.PhoneNumber, s.Email, s.Area - subArea);
            }
        }
        public static void Main()
        {
            Shop shop1 = new Shop("Магазин 1", "ул. Первая, 1", "Продуктовый", "+380-111-111-11", "shop1@gmail.com", 50);
            Shop shop2 = new Shop("Магазин 2", "ул. Вторая, 2", "Хозяйственный", "+380-222-222-22", "shop2@gmail.com", 80);
            // вывод данных для магазинов
            shop1.Output();
            shop2.Output();

            // сравнение магазинов на равенство площадей
            if (shop1 == shop2) {
                Console.WriteLine("Площади магазинов 1 и 2 равны");
            }
            else { Console.WriteLine("Площади магазинов 1 и 2 не равны");
            }

            Console.WriteLine("\nУвеличение площади магазина 1 на 20");
            shop1 += 20;
            Console.WriteLine("Площадь магазина 1 после увеличения: {0}", shop1.Area);

            Console.WriteLine("\nУменьшение площади магазина 2 на 30");
            shop2 -= 30;
            Console.WriteLine("Площадь магазина 2 после уменьшения: {0}", shop2.Area);
        }
    }
}
