# How to show Busy Indicator on each item in .NET MAUI ListView (SfListView)?

The [.NET MAUI ListView](https://www.syncfusion.com/maui-controls/maui-listview) facilitates displaying an activity indicator for each item while its data is being loaded in the background. To achieve this, place both an [ActivityIndicator](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Core.SfBusyIndicator.html?tabs=tabid-1) and a Button in the same row of a Grid element inside the [ItemTemplate](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.ListView.SfListView.html#Syncfusion_Maui_ListView_SfListView_ItemTemplate) of SfListView. Maintain a bool property in your model class, which is bound to their IsVisible property to control their visibility at runtime, as demonstrated in the code snippets below.

**C#**
```
namespace ListViewMaui
{
    public class BookInfo : INotifyPropertyChanged
    {
        private string bookName;
        private string bookDescription;
        private bool isDescriptionVisible;
        private bool isButtonVisible;
        public bool isIndicatorVisible;

        public BookInfo()
        {
        }

        public string BookName
        {
            get { return bookName; }
            set
            {
                bookName = value;
                OnPropertyChanged("BookName");
            }
        }

        public bool IsDescriptionVisible
        {
            get { return isDescriptionVisible; }
            set
            {
                isDescriptionVisible = value;
                OnPropertyChanged("IsDescriptionVisible");
            }
        }
		
        public string BookDescription
        {
            get { return bookDescription; }
            set
            {
                bookDescription = value;
                OnPropertyChanged("BookDescription");
            }
        }
       
        public bool IsButtonVisible
        {
            get { return isButtonVisible; }
            set
            {
                isButtonVisible = value;
                OnPropertyChanged("IsButtonVisible");
            }
        }
        
        public bool IsIndicatorVisible
        {
            get { return isIndicatorVisible; }
            set
            {
                isIndicatorVisible = value;
                OnPropertyChanged("IsIndicatorVisible");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
```

Disable the visibility of the Description and ActivityIndicator initially when adding items to the collection.

**C#**
```
namespace ListViewMaui
{
    public class BookInfoRepository : INotifyPropertyChanged
    {
        private ObservableCollection<BookInfo> newBookInfo;
        public event PropertyChangedEventHandler PropertyChanged;

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

        public BookInfoRepository()
        {
            GenerateNewBookInfo();
        }


        private void GenerateNewBookInfo()
        {
            NewBookInfo = new ObservableCollection<BookInfo>();
            NewBookInfo.Add(new BookInfo() { BookName = "Machine Learning Using C#", BookDescription = "You’ll learn several different approaches to applying machine learning", IsIndicatorVisible = false, IsButtonVisible = true, IsDescriptionVisible = false });
            NewBookInfo.Add(new BookInfo() { BookName = "Object-Oriented Programming in C#", BookDescription = "Object-oriented programming is the de facto programming paradigm", IsIndicatorVisible = false, IsButtonVisible = true, IsDescriptionVisible = false });
            NewBookInfo.Add(new BookInfo() { BookName = "C# Code Contracts", BookDescription = "Code Contracts provide a way to convey code assumptions", IsIndicatorVisible = false, IsButtonVisible = true, IsDescriptionVisible = false });
        }
    }
}
```

Bind the boolean values to the IsVisible properties to toggle between the ActivityIndicator and the Button while loading the description.

**XAML**
```
<ContentPage>

    <ContentPage.BindingContext>
        <local:BookInfoRepository x:Name="ViewModel" />
    </ContentPage.BindingContext>

    <sync:SfListView x:Name="listView" AutoFitMode="Height" BackgroundColor="#d3d3d3" SelectionMode="None" ItemsSource="{Binding NewBookInfo}">
        <sync:SfListView.ItemTemplate>
            <DataTemplate>
                <Frame HasShadow="True" Margin="5,5,5,0">
                    <Grid Padding="5">
                        <Grid.RowDefinitions>
                            <RowDefinition Height="*" />
                            <RowDefinition Height="2*" />
                        </Grid.RowDefinitions>
                        <Label Text="{Binding BookName}"
                               FontAttributes="Bold"
                               FontSize="19" />
                        <Button Grid.Row="1"
                                Clicked="Button_Clicked" 
                                Text="Load Description"
                                IsVisible="{Binding IsButtonVisible}" 
                                HorizontalOptions="Center" VerticalOptions="Center"/>
                        <Label Grid.Row="1"
                               Text="{Binding BookDescription}"
                               FontSize="15"
                               IsVisible="{Binding IsDescriptionVisible}" />
                        <ActivityIndicator Grid.Row="1"
                                           IsEnabled="True" 
                                           IsRunning="True" 
                                           IsVisible="{Binding IsIndicatorVisible}" />
                    </Grid>
                </Frame>
            </DataTemplate>
        </sync:SfListView.ItemTemplate>
    </sync:SfListView>

</ContentPage>
```

In the Button's Clicked event, retrieve the row data from its BindingContext and update the boolean values accordingly

**C#**
```
public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var model = ((sender as Button).BindingContext as BookInfo);
        model.IsIndicatorVisible = true;
        model.IsButtonVisible = false;
        await Task.Delay(2000);
        model.IsDescriptionVisible = true;
        model.IsIndicatorVisible = false;
    }
}
```

**Output:**
 
 ![Capture.PNG](https://support.syncfusion.com/kb/attachment/article/14853/inline?token=eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjE2NjM2Iiwib3JnaWQiOiIzIiwiaXNzIjoic3VwcG9ydC5zeW5jZnVzaW9uLmNvbSJ9.oJXkyo7KbKyhKp4npfajEdLa2RxxguZJFDG7ay8Ngdo)

**Conclusion**

I hope you enjoyed learning how to display a busy indicator on each item in .NET MAUI ListView.

You can refer to our [.NET MAUI ListView feature tour](https://www.syncfusion.com/maui-controls/maui-listview) page to know about its other groundbreaking feature representations and [documentation](https://help.syncfusion.com/maui/listview/getting-started), and how to quickly get started with configuration specifications. You can also explore our [.NET MAUI ListView example](https://github.com/syncfusion/maui-demos/tree/master/MAUI/ListView) to understand how to create and manipulate data.

Check out our components from the [License and Downloads](https://www.syncfusion.com/sales/teamlicense) page for current customers. If you are new to Syncfusion®, try our 30-day [free trial](https://www.syncfusion.com/downloads/maui) to check out our other controls.

Please let us know in the comments section if you have any queries or require clarification. You can also contact us through our [support forums](https://www.syncfusion.com/forums), [Direct-Trac](https://support.syncfusion.com/create), or [feedback portal](https://www.syncfusion.com/feedback/maui?control=sflistview). We are always happy to assist you!
