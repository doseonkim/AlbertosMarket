using System;
using AlbertosMarket.Models;

namespace AlbertosMarket.DAL
{
    public class UnitOfWork : IDisposable
    {
        private MarketContext context = new MarketContext();
        private GenericRepository<Comment> commentRepository;

        public GenericRepository<Comment> CommentRepository
        {
            get
            {
                return this.commentRepository ?? new GenericRepository<Comment>(context);
            }
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