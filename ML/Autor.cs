using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Autor
    {
        int idAutor;
        string nombre;
        List<object> autores;

        public int IdAutor { get => idAutor; set => idAutor = value; }

        [DisplayName("Autor")]
        public string Nombre { get => nombre; set => nombre = value; }
        public List<object> Autores { get => autores; set => autores = value; }
    }
}
