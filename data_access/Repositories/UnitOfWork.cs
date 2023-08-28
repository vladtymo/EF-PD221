using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Repositories
{
    public interface IUoW
    {
        IRepository<Book> BookRepo { get; }
        IRepository<Author> AuthorRepo { get; }
        void Save();
    }

    public class UnitOfWork : IUoW, IDisposable
    {
        private static LibraryDbContext context = new LibraryDbContext();
        private IRepository<Book>? bookRepo = null;
        private IRepository<Author>? authorRepo = null;
        // ...others repositories

        public IRepository<Book> BookRepo
        {
            get
            {

                if (this.bookRepo == null)
                {
                    this.bookRepo = new Repository<Book>(context);
                }
                return bookRepo;
            }
        }

        public IRepository<Author> AuthorRepo
        {
            get
            {

                if (this.authorRepo == null)
                {
                    this.authorRepo = new Repository<Author>(context);
                }
                return authorRepo;
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
