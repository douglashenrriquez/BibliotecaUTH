using BibliotecaUTH.Datos;
using BibliotecaUTH.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaUTH.Views
{
    public partial class AutoresPage : ContentPage
    {
        private BaseDatos _database;

        public AutoresPage()
        {
            InitializeComponent();
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BibliotecaUTH.db3");
            _database = new BaseDatos(dbPath);
            LoadAutores();
        }

        private async void LoadAutores()
        {
            var autores = await _database.ObtenerAutoresAsync();
            autoresCollectionView.ItemsSource = autores;
        }

        private async void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
        {
            var searchTerm = searchBar.Text;
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                autoresCollectionView.ItemsSource = await _database.ObtenerAutoresAsync();
            }
            else
            {
                autoresCollectionView.ItemsSource = await _database.BuscarAutoresAsync(searchTerm);
            }
        }
    }
}
