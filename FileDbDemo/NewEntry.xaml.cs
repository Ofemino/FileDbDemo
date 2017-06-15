using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows;
using FileDbNs;

namespace FileDbDemo
{
    /// <summary>
    /// Interaction logic for NewEntry.xaml
    /// </summary>
    public partial class NewEntry : Window
    {
        private FileDb _booksDb;


        public NewEntry()
        {
            InitializeComponent();
        }

        private void DoSubmitBook(object sender, RoutedEventArgs e)
        {
            //Reload:
            //FileDb booksDb = new FileDb();

            //booksDb.Open("Books.fdb", false);
            //if (booksDb.IsOpen)
            //{
            //    BookViewModel.BookList = booksDb.SelectAllRecords().ToList();

            //}
            //else
            //{
            //create database file
            CreateAnOpenDataBaseFile();
            _booksDb = new FileDb();
            _booksDb.Open("Books.fdb", false);

            Book book = new Book
            {
                AuthorsName = txtAuthorsName.Text,
                Mvp = txtMvp.Text,
                Title = txtTitle.Text
            };
            int p = PostData(book, _booksDb);
            if (p>0)
            {
                MessageBox.Show("Entry Successful!");
            }

            if (_booksDb.IsOpen)
            {


                BookViewModel.BookList = _booksDb.SelectAllRecords().ToList();
            }
            _booksDb.Close();
            
        }

        private int PostData(Book book, FileDb booksDb)
        {
            if (booksDb.IsOpen)
            {
                booksDb.Open("Books.fdb", false);
                var record = new FieldValues();
                record.Add("AuthorsName", book.AuthorsName);
                record.Add("Mvp", book.Mvp);
                record.Add("Title", book.Title);

                return booksDb.AddRecord(record);
            }
            return 0;
        }

        private void CreateAnOpenDataBaseFile()
        {
            FileDb booksDb = new FileDb();
            Field field;
            var fieldLst = new List<Field>(20);
            field = new Field("ID", DataTypeEnum.Int32)
            {
                AutoIncStart = 0,
                IsPrimaryKey = true
            };
            fieldLst.Add(field);
            field = new Field("AuthorsName", DataTypeEnum.String);
            fieldLst.Add(field);
            field = new Field("Age", DataTypeEnum.String);
            fieldLst.Add(field);
            field = new Field("Title", DataTypeEnum.String);
            fieldLst.Add(field);
            field = new Field("Mvp", DataTypeEnum.String);
            fieldLst.Add(field);

            booksDb.Create("Books.fdb", fieldLst.ToArray());
            booksDb.Close();
        }
    }
}
