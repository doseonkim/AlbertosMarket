using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlbertosMarket.Models
{
    using System;
    using System.Collections.Generic;

        public interface IAuthorRepository : IDisposable
        {
            IEnumerable<Author> GetAuthors();
            Author GetAuthorById(String authorId);
            void InsertAuthor(Author author);
            void DeleteAuthor(String authorID);
            void UpdateAuthor(Author author);
            void Save();
        }
    
}