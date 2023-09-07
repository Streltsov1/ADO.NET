using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string conn = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Library;Integrated Security=True;Connect Timeout=3;Encrypt=False;";
            DataClasses2DataContext context = new DataClasses2DataContext(conn);

            //1 task
            var filtered = context.Books.Where(x => x.PageNumbers > 800);
            foreach (var book in filtered)
            {
                Console.WriteLine($"{book.Id} - {book.Name} - {book.PageNumbers} - {book.Author.Name} {book.Author.Surname}");
            }
            Console.WriteLine("---------------------------------------------");

            //2 task
            filtered = context.Books.Where(x => x.Name.ToLower()[0] == 'g');
            foreach (var book in filtered)
            {
                Console.WriteLine($"{book.Id} - {book.Name} - {book.PageNumbers} - {book.Author.Name} {book.Author.Surname}");
            }
            Console.WriteLine("---------------------------------------------");

            //3 task

            filtered = context.Books.Where(x => x.Author.Name == "David" && x.Author.Surname == "Brown");
            foreach (var book in filtered)
            {
                Console.WriteLine($"{book.Id} - {book.Name} - {book.PageNumbers} - {book.Author.Name} {book.Author.Surname}");
            }
            Console.WriteLine("---------------------------------------------");

            //4 task
            filtered = context.Books.Where(x => x.Author.Country.Name == "United States").OrderBy(x => x.Name);
            foreach (var book in filtered)
            {
                Console.WriteLine($"{book.Id} - {book.Name} - {book.PageNumbers} - {book.Author.Name} {book.Author.Surname}");
            }
            Console.WriteLine("---------------------------------------------");
            //5 task
            filtered = context.Books.Where(x => x.Name.ToString().Length <= 10);
            foreach (var book in filtered)
            {
                Console.WriteLine($"{book.Id} - {book.Name} - {book.PageNumbers}");
            }
            Console.WriteLine("---------------------------------------------");
            //6 task
            filtered = context.Books.Where(x => x.Author.Country.Name == "United States").OrderByDescending(x => x.PageNumbers).Take(1);
            foreach (var book in filtered)
            {
                Console.WriteLine($"{book.Id} - {book.Name} - {book.PageNumbers} - {book.Author.Name} {book.Author.Surname}");
            }
            Console.WriteLine("---------------------------------------------");
            //7 task
            var result =
                from b in context.Books
                join a in context.Authors on b.AuthorId equals a.Id
                orderby b.PageNumbers descending
                group a.Id by a.Id into g
                select new { numberOfBook = g.Count()};
            Console.WriteLine($"{result.ToList()[0].numberOfBook}");
            Console.WriteLine("---------------------------------------------");
        }
    }
}
