using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewMaui
{
    public class BookInfoRepository : INotifyPropertyChanged
    {
        private ObservableCollection<BookInfo> newBookInfo;
        public event PropertyChangedEventHandler PropertyChanged;

        #region Properties

        public ObservableCollection<BookInfo> NewBookInfo
        {
            get { return newBookInfo; }
            set { this.newBookInfo = value; }
        }

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion

        #region Constructor

        public BookInfoRepository()
        {
            GenerateNewBookInfo();
        }

        #endregion

        #region Properties

        private void GenerateNewBookInfo()
        {
            NewBookInfo = new ObservableCollection<BookInfo>();
            NewBookInfo.Add(new BookInfo() { BookName = "Machine Learning Using C#", BookDescription = "You’ll learn several different approaches to applying machine learning", IsIndicatorVisible = false, IsButtonVisible = true, IsDescriptionVisible = false });
            NewBookInfo.Add(new BookInfo() { BookName = "Object-Oriented Programming in C#", BookDescription = "Object-oriented programming is the de facto programming paradigm", IsIndicatorVisible = false, IsButtonVisible = true, IsDescriptionVisible = false });
            NewBookInfo.Add(new BookInfo() { BookName = "C# Code Contracts", BookDescription = "Code Contracts provide a way to convey code assumptions", IsIndicatorVisible = false, IsButtonVisible = true, IsDescriptionVisible = false });
        }

        #endregion

    }
}
