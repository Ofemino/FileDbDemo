using System.Collections.Generic;
using System.Windows;

namespace FileDbDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenTestCamera(object sender, RoutedEventArgs e)
        {
            TestCamera tc = new TestCamera();
            tc.ShowDialog();

        }

        List<Book> SetDefaultData()
        {
            List<Book> bookList = new List<Book>();
            var book = new Book { Age = "20", AuthorsName = "Femi Adesanya", Mvp = "Microsoft Programming", Title = "C# Programming." };
            bookList.Add(book);
            var book1 = new Book { Age = "30", AuthorsName = "John Doe", Mvp = "VB Programming", Title = "Vb Programming." };
            bookList.Add(book1);
            var book2 = new Book { Age = "40", AuthorsName = "Greg Nelson", Mvp = "Java Programming", Title = "Java Programming." };
            bookList.Add(book2);
            var book3 = new Book { Age = "50", AuthorsName = "Femi Adesanya", Mvp = "Microsoft Programming", Title = "C# Programming." };
            bookList.Add(book3);

            return bookList;
        }

        private void DoDataBinding(object sender, RoutedEventArgs e)
        {
            booksLst.ItemsSource = SetDefaultData();
            //booksLst.
        }

        private void OpenNewEntryFrm(object sender, RoutedEventArgs e)
        {
            NewEntry frm = new NewEntry();
            frm.ShowDialog();
        }

        private void DoRefreshGrid(object sender, RoutedEventArgs e)
        {
            if (BookViewModel.BookList != null)
            {
                booksLst.ItemsSource = BookViewModel.BookList;
            }

        }
    }
}
