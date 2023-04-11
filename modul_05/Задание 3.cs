using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modul_05
{
    /*
      Задание 3
    Создайте приложение «Список книг для прочтения». 
    Приложение должно позволять добавлять книги в список, удалять книги из списка, проверять есть ли книга в списке, и т. д. 
    Используйте механизм свойств, перегрузки операторов, индексаторов. */
    public class Program
    {
        public static void Main()
        {
            BookList myBooks = new BookList();
            myBooks.Add(new Book("Путеводитель автостопом по галактике", "Дуглас Адамс", 1979));
            myBooks += new Book("Властелин колец", "Дж.Р.Р. Толкин", 1954);
            Console.WriteLine(myBooks);

            Book bookToRemove = new Book("Путеводитель автостопом по галактике", "Дуглас Адамс", 1979);
            myBooks -= bookToRemove;
            Console.WriteLine(myBooks);

            Book bookToFind = new Book("Хоббит", "Дж.Р.Р. Толкин", 1937);
            Console.WriteLine("Список книг  " + (myBooks.Contains(bookToFind) ? "содержит " : "не содержит ") + bookToFind.ToString());
        }
        public class Book
        {
            private string title;   
            private string author;
            private int year;
            public Book(string title, string author, int year)
            {
                this.title = title;
                this.author = author;
                this.year = year;
            }
            public string Title
            {
                get { return title; }
                set { title = value; }
            }
            public string Author
            {
                get { return author; }
                set { author = value; }
            }
            public int Year
            {
                get { return year; }
                set { year = value; }
            }
            public override string ToString()
            {
                return String.Format("{0} ({1}) {2}", title, year, author);
            }
            // Equals это метод класса object, который сравнивает два объекта на равенство.
            // Метод возвращает булевое значение: true, если объекты равны, и false, если объекты не равны.
            public override bool Equals(object obj)
            {
                if (!(obj is Book))
                    return false;

                Book other = (Book)obj;
                return this.title == other.title && this.author == other.author && this.year == other.year;
            }
            // "GetHashCode" является методом, который можно использовать для получения уникального числового значения (хэш-кода) из объекта.
            // Этот метод используется для оптимизации производительности в процессе поиска или сортировки объектов. 
            public override int GetHashCode()
            {
                return title.GetHashCode() ^ author.GetHashCode() ^ year.GetHashCode();
                // Символ ^ означает операцию побитового исключающего ИЛИ (XOR) между значениями.
            }
            public static bool operator ==(Book a, Book b)
            {
                if (System.Object.ReferenceEquals(a, b))
                    return true;

                if (((object)a == null) || ((object)b == null))
                    return false;

                return a.Equals(b);
            }
            public static bool operator !=(Book a, Book b)
            {
                return !(a == b);
            }
        }
        public class BookList
        {
            private List<Book> books;
            // создаем список книг
            public BookList()
            {
                books = new List<Book>();
            }
            // Добавляем книгу в список
            public void Add(Book book)
            {
                books.Add(book);
            }
            // Удаляем книгу из списка
            public void Remove(Book book)
            {
                books.Remove(book);
            }
            // Проверка есть ли книга в списке
            public bool Contains(Book book)
            {
                return books.Contains(book);
            }
            // Оператор this указывает на текущий объект, к которому применяется индексатор.
            public Book this[int index]
            {
                // возвращает книгу из списка по указанному индексу
                get { return books[index]; }
                // устанавливать значения по указанному индексу
                set { books[index] = value; }
            }
            public static BookList operator +(BookList list, Book book)
            {
                list.Add(book);
                return list;
            }
            public static BookList operator -(BookList list, Book book)
            {
                list.Remove(book);
                return list;
            }
            public override string ToString()
            {
                string result = "Список книг:\n";
                foreach (Book book in books)
                {
                    result += book.ToString() + "\n";
                }
                return result;
            }
        }
    }
}
