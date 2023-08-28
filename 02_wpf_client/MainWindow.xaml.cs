using data_access;
using data_access.Repositories;
using System;
using System.Linq;
using System.Windows;

namespace _02_wpf_client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private IRepository<Book> bookRepo = null;
        //private IRepository<Author> authorRepo = null;
        private IUoW unitOfWork = new UnitOfWork();

        public MainWindow()
        {
            InitializeComponent();

            //var ctx = new LibraryDbContext();
            //bookRepo = new Repository<Book>(ctx);
            //authorRepo = new Repository<Author>(ctx);

            tableView.ItemsSource = unitOfWork.BookRepo.Get(includeProperties: "Review").Select(x => new
            {
                x.Id,
                x.Title,
                x.Year,
                Summary = (x.Review != null ? x.Review.Summary : null),
                ReviewData = (x.Review != null ? x.Review.Date : DateTime.Now),
            });

            unitOfWork.AuthorRepo.GetByID(1);
        }
    }
}
