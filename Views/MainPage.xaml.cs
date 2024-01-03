namespace ListViewMaui
{
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

}
