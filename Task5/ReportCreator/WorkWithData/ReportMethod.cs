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
            List<int> list = new List<int>();
            foreach (var book in books)
            {
                foreach (var author in authors)
                {
                    if (book.AuthorId == author.Id)
                    {
                        list.Add(author.Id);
                    }
                }
            }

            var result = list.GroupBy(x => x).OrderByDescending(g => g.Count()).First().Key;
            return authors.First(o => o.Id == result);
        }
        public static List<Book> GetBadBookList(List<Book> books, List<ClientBookHistory> histories)
        {
            var badBooks = new List<Book>();
            for (var i = 0; i < histories.Count(); i++)
            {
                if (histories[i].BookCondition == "Worn out")
                {
                    badBooks?.Add(books.First(o => o.Id == histories[i].BookId));
                }
            }

            return badBooks;
        }
    }
}
