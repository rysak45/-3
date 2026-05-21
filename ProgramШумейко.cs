using System;

namespace BookLibrary
{
    public class Book
    {
        private string title;
        private string author;
        private int year;
        private string genre;

        private static readonly string[] validGenres = { "Художественная", "Методическая", "Справочная", "Научная", "Детская" };

        public Book(string title, string author, int year, string genre)
        {
            SetTitle(title);
            SetAuthor(author);
            SetYear(year);
            SetGenre(genre);
            Console.WriteLine($"Конструктор: создана книга \"{this.title}\"");
        }

        ~Book()
        {
            Console.WriteLine($"Деструктор: книга \"{title}\" уничтожена");
        }

        public void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Название не может быть пустым");
            this.title = title;
        }

        public void SetAuthor(string author)
        {
            if (string.IsNullOrWhiteSpace(author))
                throw new ArgumentException("Автор не может быть пустым");
            this.author = author;
        }

        public void SetYear(int year)
        {
            int currentYear = DateTime.Now.Year;
            if (year < 0 || year > currentYear)
                throw new ArgumentOutOfRangeException(nameof(year), $"Год должен быть от 0 до {currentYear}");
            this.year = year;
        }

        public void SetGenre(string genre)
        {
            if (Array.IndexOf(validGenres, genre) == -1)
                throw new ArgumentException($"Допустимые жанры: {string.Join(", ", validGenres)}");
            this.genre = genre;
        }

        public string GetTitle() => title;
        public string GetAuthor() => author;
        public int GetYear() => year;
        public string GetGenre() => genre;

        public int GetAge()
        {
            return DateTime.Now.Year - year;
        }

        public void Print()
        {
            Console.WriteLine($"Книга: \"{title}\"");
            Console.WriteLine($"Автор: {author}");
            Console.WriteLine($"Год выпуска: {year}");
            Console.WriteLine($"Вид литературы: {genre}");
            Console.WriteLine($"Возраст книги: {GetAge()} лет");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Book book1 = new Book("Война и мир", "Лев Толстой", 1869, "Художественная");
                book1.Print();

                Book book2 = new Book("1984", "Джордж Оруэлл", 1949, "Художественная");
                book2.Print();

                // Некорректный год
                Book book3 = new Book("Футурология", "Автор", 2030, "Научная");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            try
            {
                Book book4 = new Book("", "", -5, "Фантастика");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}
