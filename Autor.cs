using SQLite;

namespace BibliotecaUTH.Modelos
{
    public class Autor
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Nacionalidad { get; set; }
        public string Imagen { get; set; } 
    }
}
