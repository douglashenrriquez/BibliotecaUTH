using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SQLite;
using BibliotecaUTH.Modelos;

namespace BibliotecaUTH.Datos
{
    public class BaseDatos
    {
        private readonly SQLiteAsyncConnection _database;

        public BaseDatos(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Autor>().Wait();
        }

        public Task<int> GuardarAutorAsync(Autor autor)
        {
            return _database.InsertAsync(autor);
        }

        public Task<List<Autor>> ObtenerAutoresAsync()
        {
            return _database.Table<Autor>().ToListAsync();
        }

        public Task<List<Autor>> BuscarAutoresAsync(string searchTerm)
        {
            return _database.Table<Autor>()
                            .Where(a => a.Nombre.Contains(searchTerm) || a.Nacionalidad.Contains(searchTerm))
                            .ToListAsync();
        }
    }
}
