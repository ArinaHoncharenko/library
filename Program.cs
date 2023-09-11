using System;
using System.Collections.Generic;

class Book
{
    // Клас, що представляє книгу з властивостями
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
    public string ISBN { get; set; }

    // Конструктор класу Book для створення об'єкту книги
    public Book(string title, string author, int year, string isbn)
    {
        Title = title;
        Author = author;
        Year = year;
        ISBN = isbn;
    }
}

class Library
{
    // Клас, що представляє бібліотеку зі списком книг
    private List<Book> books = new List<Book>();

    // Метод для додавання книги до бібліотеки
    public void AddBook()
    {
        // Зчитування від користувача інформації про книгу
        Console.WriteLine("Enter the title of the book:");
        string title = Console.ReadLine();
        Console.WriteLine("Enter the author of the book:");
        string author = Console.ReadLine();
        Console.WriteLine("Enter the year the book was written:");

        // Зчитування і перевірка на коректність року
        if (int.TryParse(Console.ReadLine(), out int year))
        {
            Console.WriteLine("Enter the ISBN of the book:");
            string isbn = Console.ReadLine();

            // Створення об'єкту книги і додавання його до списку книг бібліотеки
            Book book = new Book(title, author, year, isbn);
            books.Add(book);

            // Виведення повідомлення про успішне додавання
            Console.WriteLine("\nNew book added: " + title + " - " + author + " - " + year + " - " + isbn);
        }
        else
        {
            // Виведення повідомлення про некоректний ввід року
            Console.WriteLine("Invalid year input.");
        }
    }

    // Метод для видалення книги з бібліотеки за назвою
    public void RemoveBook()
    {
        Console.WriteLine("Enter the title of the book to remove:");
        string titleToRemove = Console.ReadLine();

        // Пошук книги за назвою та видалення її зі списку
        Book bookToRemove = books.Find(book => book.Title.Equals(titleToRemove));
        if (bookToRemove != null)
        {
            books.Remove(bookToRemove);
            Console.WriteLine("Book " + titleToRemove + " removed from the library.");
        }
        else
        {
            Console.WriteLine($"Book " + titleToRemove + " not found in the library.");
        }
    }

    // Метод для пошуку книг за автором
    public void SearchByAuthor()
    {
        Console.WriteLine("Enter author's name:");
        string authorToSearch = Console.ReadLine();

        // Пошук книг за автором та виведення результатів
        List<Book> result = books.FindAll(book => book.Author.Equals(authorToSearch));
        if (result.Count >0)
        {
            Console.WriteLine("Books by author:");
            foreach (var book in result)
            {
                Console.WriteLine(book.Title + " - " + book.Author + " - " + book.Year + " - " + book.ISBN);
            }
        }
        else
        {
            Console.WriteLine("No books by " + authorToSearch + " found in the library.");
        }
    }

    // Метод для пошуку книг за назвою
    public void SearchByTitle()
    {
        Console.WriteLine("Enter title to search for:");
        string titleToSearch = Console.ReadLine();

        // Пошук книг за назвою та виведення результатів
        List<Book> result = books.FindAll(book => book.Title.Equals(titleToSearch));
        if (result.Count > 0)
        {
            Console.WriteLine("Books with title " + titleToSearch + " :");
            foreach (var book in result)
            {
                Console.WriteLine(book.Title + " - " + book.Author + " - " + book.Year + " - " + book.ISBN);
            }
        }
        else
        {
            Console.WriteLine("No books with title " + titleToSearch + " found in the library.");
        }
    }

    // Метод для виведення всіх книг у бібліотеці
    public void ListAllBooks()
    {
        if (books.Count > 0)
        {
            Console.WriteLine("All books in the library:");
            foreach (var book in books)
            {
                Console.WriteLine(book.Title + " - " + book.Author + " - " + book.Year + " - " + book.ISBN);
            }
        }
        else
        {
            Console.WriteLine("The library is empty.");
        }
    }
}

namespace oop1_library
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

        Menu:
            // Виведення меню для користувача
            Console.WriteLine("\nChoose an action to perform:\n1. Add\n2. Delete\n3. Search\n4. See a list");

            if (int.TryParse(Console.ReadLine(), out int act))
            {
                // Введене значення успішно перетворено у ціле число (act - вибір користувача)

                switch (act)
                {
                    case 1:
                        // Користувач обрав додавання книги
                        library.AddBook();
                        break;
                    case 2:
                        // Користувач обрав видалення книги
                        library.RemoveBook();
                        break;
                    case 3:
                        Console.WriteLine("Choose a search method:\n1. By title\n2. By author");

                        if (int.TryParse(Console.ReadLine(), out int met))
                        {
                            // Користувач обрав пошук за назвою або автором

                            switch (met)
                            {
                                case 1:
                                    // Користувач обрав пошук за назвою книги
                                    library.SearchByTitle();
                                    break;
                                case 2:
                                    // Користувач обрав пошук за автором книги
                                    library.SearchByAuthor();
                                    break;
                                default:
                                    Console.WriteLine("Invalid search method.");
                                    break;
                            }
                        }
                        else
                        {
                            // Некоректний ввід для методу пошуку
                            Console.WriteLine("Invalid input for search method.");
                        }
                        break;
                    case 4:
                        // Користувач обрав перегляд всіх книг
                        library.ListAllBooks();
                        break;
                    default:
                        // Некоректний вибір користувача
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                // Некоректний ввід користувача (не ціле число)
                Console.WriteLine("Invalid choice. Please enter a valid number.");
            }
            goto Menu;

        }
    }
}
