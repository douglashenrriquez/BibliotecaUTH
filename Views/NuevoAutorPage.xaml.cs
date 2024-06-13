using Plugin.Media;
using Plugin.Media.Abstractions;
using BibliotecaUTH.Modelos;

namespace BibliotecaUTH.Views
{
    public partial class NuevoAutorPage : ContentPage
    {
        private string _rutaImagen;

        public NuevoAutorPage()
        {
            InitializeComponent();
            _rutaImagen = string.Empty;
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nombreEntry.Text) && nacionalidadPicker.SelectedItem != null)
            {
                var autor = new Autor
                {
                    Nombre = nombreEntry.Text,
                    Nacionalidad = nacionalidadPicker.SelectedItem.ToString(),
                    Imagen = _rutaImagen
                };
                await App.BaseDatos.GuardarAutorAsync(autor);
                await DisplayAlert("Éxito", "Autor guardado exitosamente", "OK");
                nombreEntry.Text = string.Empty;
                nacionalidadPicker.SelectedItem = null;
                _rutaImagen = string.Empty;
            }
            else
            {
                await DisplayAlert("Error", "Todos los campos son requeridos", "OK");
            }
        }

        private async void OnImageTapped(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = $"{DateTime.UtcNow}.jpg"
            });

            if (file == null)
                return;

            _rutaImagen = file.Path;
            imagen.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });
        }
    }
}
