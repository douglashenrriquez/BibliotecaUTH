namespace BibliotecaUTH
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnNuevoAutorClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.NuevoAutorPage());
        }

        private async void OnAutoresClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.AutoresPage());
        }
    }
}
