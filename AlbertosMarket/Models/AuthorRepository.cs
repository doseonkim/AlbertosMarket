using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using AlbertosMarket.Models;
using System.Data.Entity;

namespace AlbertosMarket.DAL
{
    public class AuthorRepository : IAuthorRepository, IDisposable
    {
        private MarketContext context;

        public AuthorRepository(MarketContext context)
        {
            this.context = context;
        }

        public IEnumerable<Author> GetAuthors()
        {
            return context.Authors.ToList();
        }

        public Author GetAuthorById(String id)
        {
            return context.Authors.Find(id);
        }

        public void InsertAuthor(Author Author)
        {
            context.Authors.Add(Author);
        }

        public void DeleteAuthor(String AuthorID)
        {
            Author Author = context.Authors.Find(AuthorID);
            context.Authors.Remove(Author);
        }

        public void UpdateAuthor(Author Author)
        {
            context.Entry(Author).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}