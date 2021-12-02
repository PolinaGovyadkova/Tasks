using System;
using System.Collections.Generic;
using System.Linq;
using ORM.Table;

namespace ReportWork.WorkWithData.Method
{
    /// <summary>
    /// ReportMethod
    /// </summary>
    public static class ReportMethod
    {
        /// <summary>
        /// Most the popular author.
        /// </summary>
        /// <param name="authors">The authors.</param>
        /// <param name="books">The books.</param>
        /// <returns></returns>
        public static Author MostPopularAuthor(List<Author> authors, List<Book> books)
        {
            var list = (from book in books from author in authors where book.AuthorId == author.Id select author.Id).ToList();
            var result = list.GroupBy(x => x).OrderByDescending(g => g.Count()).First().Key;
            return authors.First(o => o.Id == result);
        }

        /// <summary>
        /// Gets the bad book list.
        /// </summary>
        /// <param name="books">The books.</param>
        /// <param name="histories">The histories.</param>
        /// <returns></returns>
        public static List<Book> GetBadBookList(List<Book> books, List<ClientBookHistory> histories) => (from history in histories where history.BookCondition == "Worn out" select books.First(o => o.Id == history.BookId)).ToList();

        /// <summary>
        /// Gets the popular genre.
        /// </summary>
        /// <param name="books">The books.</param>
        /// <param name="genres">The genres.</param>
        /// <returns></returns>
        public static Genre GetPopularGenre(List<Book> books, List<Genre> genres)
        {
            var list = (from book in books from genre in genres where book.GenreId == genre.Id select genre.Id).ToList();
            var result = list.GroupBy(x => x).OrderByDescending(g => g.Count()).First().Key;
            return genres.First(o => o.Id == result);
        }

        /// <summary>
        /// Gets the most reading subscriber.
        /// </summary>
        /// <param name="histories">The histories.</param>
        /// <param name="clients">The clients.</param>
        /// <returns></returns>
        public static Client GetMostReadingSubscriber(List<ClientBookHistory> histories, List<Client> clients)
        {
            var list = (from history in histories from client in clients where history.ClientId == client.Id select client.Id).ToList();
            var result = list.GroupBy(x => x).OrderByDescending(g => g.Count()).First().Key;
            return clients.First(o => o.Id == result);
        }

        /// <summary>
        /// Eaches the subscriber books for date.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="finish">The finish.</param>
        /// <param name="clients">The clients.</param>
        /// <param name="books">The books.</param>
        /// <param name="clientBookHistories">The client book histories.</param>
        /// <returns></returns>
        public static string EachSubscriberBooksForDate(DateTime start, DateTime finish, List<Client> clients, List<Book> books, List<ClientBookHistory> clientBookHistories)
        {
            // List<string>
            var result = "";
            foreach (var s in clients)
            {
                var booksPerSubscriber = new List<Book>();
                foreach (var bt in clientBookHistories.Where(bt => bt.ReceivingDate >= start && bt.ReceivingDate <= finish))
                {
                    booksPerSubscriber.AddRange(books.Where(b => b.Id == bt.BookId && bt.ClientId == s.Id));
                }
                if (booksPerSubscriber.Count > 0)
                {
                    result += $" {start.ToShortDateString()} to {finish.ToShortDateString()} {s.FullName} took books:\n";
                    result = booksPerSubscriber.OrderBy(b => b.GenreId).Aggregate(result, (current, b) => current + $"{b.Name}\n");
                }
                else
                {
                    result += $"{start.ToShortDateString()} to {finish.ToShortDateString()} {s.FullName} didn't take books:\n";
                }
            }
            return result;
        }

    }
}