using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using WpfCRUDApp.Core;
using WpfCRUDApp.Model.Book;

namespace WpfCRUDApp.ViewModel
{
    class BookViewModel : ObservableObject
    {

        private bool updateBtnVisibility;
        public bool UpdateBtnVisibility
        {
            get { return updateBtnVisibility; }
            set
            {
                updateBtnVisibility = value;
                OnPropertyChanged("UpdateBtnVisibility");
            }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set
            {
               title = value;
               OnPropertyChanged("Title");
            }
        }

        private string author;
        public string Author
        {
            get { return author; }
            set
            {
                author = value;
                OnPropertyChanged("Author");
            }
        }

        private string publisher;
        public string Publisher
        {
            get { return publisher; }
            set
            {
                publisher = value;
                OnPropertyChanged("Publisher");
            }
        }
        private int price;
        public int Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        private object selectedItem;
        public object SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }
        public RelayCommand Save { get; set; }
        public RelayCommand Delete { get; set; }
        public RelayCommand Select { get; set; }
        public RelayCommand Update { get; set; }

        public BookViewModel()
        {
            FillList();
            UpdateBtnVisibility = false;
            Save = new RelayCommand(SaveCmdExe, CanSaveCmdExe);
            Delete = new RelayCommand(DeleteCmdExe, CanDeleteCmdExe);
            Select = new RelayCommand(SelectCmdExe, CanSelectCmdExe);
            Update = new RelayCommand(UpdateCmdExe, CanUpdateCmdExe);
        }

        private void SaveCmdExe(object param)
        {
            BookRepository.Save(title, author, publisher, price);
            Title = string.Empty;
            Author = string.Empty;
            Publisher = string.Empty;
            Price = 0;
            Refresh();
            MessageBox.Show("도서 등록에 성공하셨습니다.");
        }

        private bool CanSaveCmdExe(object param)
        {
            return true;
        }

        private void DeleteCmdExe(object param)
        {
            Book book = (Book)selectedItem;
            BookRepository.Delete(book.Id);
            Refresh();
        }
        private bool CanDeleteCmdExe(object param)
        {
            return true;
        }
        private int selectedId;
        private void SelectCmdExe(object param)
        {
            Book book = (Book)selectedItem;
            UpdateBtnVisibility = true;
            selectedId = book.Id;
            FillTextBox(book);


        }
        public bool CanSelectCmdExe(object param)
        {
            return true;
        }
        
        public void UpdateCmdExe(object param)
        {
            BookRepository.Update(selectedId, title, author, publisher, price);
            Refresh();

        }

        public bool CanUpdateCmdExe(object param)
        {
            return true;
        }
        ObservableCollection<Book> books = null;
        public ObservableCollection<Book> Books
        {
            get
            {
                if (books == null) books = new ObservableCollection<Book>();
                return books;
            }
            set
            {
                books = value;
            }
        }

        private void FillTextBox(Book book)
        {
            Title = book.Title;
            Author = book.Author;
            Publisher = book.Publisher;
            Price = book.Price;
        }

        private void FillList()
        {
            DataSet ds = BookRepository.FindAll();
            for(int i=0; i<ds.Tables[0].Rows.Count; i++)
            {
                Book book = new Book
                {
                    Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"]),
                    Title = ds.Tables[0].Rows[i]["Title"].ToString(),
                    Author = ds.Tables[0].Rows[i]["Author"].ToString(),
                    Publisher = ds.Tables[0].Rows[i]["Publisher"].ToString(),
                    Price = Convert.ToInt32(ds.Tables[0].Rows[i]["Price"])
                };
                Books.Add(book);
            }
            
        }

        private void Refresh()
        {
            Books.Clear();
            FillList();
        }
    }
}
