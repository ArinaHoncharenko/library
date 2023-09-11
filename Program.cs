using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Book
{ 
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
    public string ISBN { get; set; }

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
    private List<Book> books = new List<Book>();

    public void AddBook()
    {
        Console.WriteLine("Enter the title of the book:");
        string title = Console.ReadLine();
        Console.WriteLine("Enter the author of the book:");
        string author = Console.ReadLine();
        Console.WriteLine("Enter the year the book was written:");
        if (int.TryParse(Console.ReadLine(), out int year))
        {
            Console.WriteLine("Enter the ISBN of the book:");
            string isbn = Console.ReadLine();

            Book book = new Book(title, author, year, isbn);
            books.Add(book);
            Console.WriteLine("\nNew book added: " + title + " - " + author + " - " + year + " - " + isbn);
        }
        else{Console.WriteLine("Invalid year input.");}
    }

    public void RemoveBook()
    {
        Console.WriteLine("Enter the title of the book to remove:");
        string titleToRemove = Console.ReadLine();
        Book bookToRemove = books.Find(book => book.Title.Equals(titleToRemove));
        if (bookToRemove != null)
        {
            books.Remove(bookToRemove);
            Console.WriteLine("Book "+ titleToRemove+ " removed from the library.");
        }
        else{Console.WriteLine($"Book "+ titleToRemove+ " not found in the library.");}
    }

    public void SearchByAuthor()
    {
        Console.WriteLine("Enter author's name:");
        string authorToSearch = Console.ReadLine();
        List<Book> result = books.FindAll(book => book.Author.Equals(authorToSearch));
        if (result != null)
        {
            Console.WriteLine("Books by author:");
            foreach (var book in result)
            {Console.WriteLine(book.Title + " - " + book.Author + " - " + book.Year + " - " + book.ISBN);}
        }
        else { Console.WriteLine("No books by " + authorToSearch + " found in the library.");}
    }

    public void SearchByTitle()
    {
        Console.WriteLine("Enter title to search for:");
        string titleToSearch = Console.ReadLine();
        List<Book> result = books.FindAll(book => book.Title.Equals(titleToSearch));
        if (result != null)
        {
            Console.WriteLine("Books with title " +titleToSearch+" :");
            foreach (var book in result)
            {Console.WriteLine(book.Title + " - " + book.Author + " - " + book.Year + " - " + book.ISBN);}
        }
        else {Console.WriteLine("No books with title "+titleToSearch+" found in the library."); }
    }

    public void ListAllBooks()
    {
        if (books.Count > 0)
        {
            Console.WriteLine("All books in the library:");
            foreach (var book in books)
            {Console.WriteLine(book.Title + " - " + book.Author + " - " + book.Year + " - " + book.ISBN);}
        }
        else
        {Console.WriteLine("The library is empty.");}
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
                Console.WriteLine("\nChoose an action to perform:\n1. Add\n2. Delete\n3. Search\n4. See a list");
                if (int.TryParse(Console.ReadLine(), out int act))
                {
                    switch (act)
                    {
                        case 1: library.AddBook(); break;
                        case 2: library.RemoveBook(); break;
                        case 3: Console.WriteLine("Choose a search method:\n1. By title\n2. By author");
                           
                        if (int.TryParse(Console.ReadLine(), out int met))
                        {
                            switch(met)
                            {
                                case 1: library.SearchByTitle(); break; 
                                case 2: library.SearchByAuthor(); break;
                                default: Console.WriteLine("Invalid search method."); break;
                            }
                        }
                        else {Console.WriteLine("Invalid input for search method.");} 
                            break;
                        case 4: library.ListAllBooks(); break;
                        default: Console.WriteLine("Invalid choice. Please try again."); break;
                    }
                }
                else{ Console.WriteLine("Invalid choice. Please enter a valid number.");}
            goto Menu;
        }
    }
}
