using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridViewListView.Models
{
    public class BookManager
    {
        public static List<Book> GetBooks()
        {
            var books = new List<Book>();
            books.Add(new Book { BookId = 1, Title = "Vulpate", Author = "Futurum", CoverImage = "Assets/1.png" });
            books.Add(new Book { BookId = 2, Title = "Mazim", Author = "Sequiter Que", CoverImage = "Assets/2.png" });
            books.Add(new Book { BookId = 3, Title = "Elit", Author = "Tempor", CoverImage = "Assets/3.png" });
            books.Add(new Book { BookId = 4, Title = "Elit", Author = "Tempor", CoverImage = "Assets/4.png" });
            books.Add(new Book { BookId = 5, Title = "Elit", Author = "Tempor", CoverImage = "Assets/5.png" });
            books.Add(new Book { BookId = 6, Title = "Elit", Author = "Tempor", CoverImage = "Assets/6.png" });
            books.Add(new Book { BookId = 7, Title = "Elit", Author = "Tempor", CoverImage = "Assets/7.png" });
            books.Add(new Book { BookId = 8, Title = "Elit", Author = "Tempor", CoverImage = "Assets/8.png" });
            books.Add(new Book { BookId = 9, Title = "Elit", Author = "Tempor", CoverImage = "Assets/9.png" });
            books.Add(new Book { BookId = 10, Title = "Elit", Author = "Tempor", CoverImage = "Assets/10.png" });
            books.Add(new Book { BookId = 11, Title = "Elit", Author = "Tempor", CoverImage = "Assets/11.png" });
            books.Add(new Book { BookId = 12, Title = "Elit", Author = "Tempor", CoverImage = "Assets/12.png" });
            books.Add(new Book { BookId = 13, Title = "Elit", Author = "Tempor", CoverImage = "Assets/13.png" });
            return books;
        }
    }
}
