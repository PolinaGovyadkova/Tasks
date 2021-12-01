using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM.Table;

namespace ReportCreator.WorkWithData
{
    public static class ReportMethod
    {

        public static Author MostPopularAuthor(List<Author> authors, List<Book> books)
        {
            int count = 0;
            var list = (from book in books from author in authors where book.AuthorId == author.Id select author.Id).ToList();
            var result = list.GroupBy(x => x).OrderByDescending(g => g.Count()).First().Key;
            return authors.First(o => o.Id == result);
        }
        public static List<Book> GetBadBookList(List<Book> books, List<ClientBookHistory> histories) => (from history in histories where history.BookCondition == "Worn out" select books.First(o => o.Id == history.BookId)).ToList();

        public static Genre GetPopularGenre(List<Book> books, List<Genre> genres)
        {
            var bookId = 0;
            var list = (from book in books from genre in genres where book.GenreId == genre.Id select genre.Id).ToList();
            var result = list.GroupBy(x => x).OrderByDescending(g => g.Count()).First().Key;
            return genres.First(o => o.Id == result);
        }
        public static int GetQuantityBorrowedBooks(List<Book> books, List<ClientBookHistory> histories) => (from book in books from history in histories where book.Id == history.BookId && history.IsReturn == false select book).Count();

        public static Client GetMostReadingSubscriber(List<ClientBookHistory> histories, List<Client> subscribers)
        {
            var list = (from history in histories from client in subscribers where history.ClientId == client.Id select client.Id).ToList();
            var result = list.GroupBy(x => x).OrderByDescending(g => g.Count()).First().Key;
            return subscribers.First(o => o.Id == result);
        }
    }
}
