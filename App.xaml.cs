using BibliotecaUTH.Datos;
using System.IO;

namespace BibliotecaUTH
{
    public partial class App : Application
    {
        static BaseDatos baseDatos;

        public static BaseDatos BaseDatos
        {
            get
            {
                if (baseDatos == null)
                {
                    baseDatos = new BaseDatos(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BibliotecaUTH.db3"));
                }
                return baseDatos;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
