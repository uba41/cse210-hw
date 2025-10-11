using System;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book();
            book1.SetAuthor("Smith");
            book1.SetTitle("A Great Book");

            Console.WriteLine(book1.GetBookInfo());

            PictureBook book2 = new PictureBook();
            book2.SetAuthor("Jones");
            book2.SetTitle("A wondeful Picture book");
            book2.SetIllustrator("Burton");

            Console.WriteLine(book2.GetBookInfo());
            Console.WriteLine(book2.GetPictureBookInfo());

            Book book3 = new Book("Edward", "Another book");
            Console.WriteLine(book3.GetBookInfo());

            PictureBook book4 = new PictureBook();
            Console.WriteLine(book4.GetBookInfo());

        }
    }
}