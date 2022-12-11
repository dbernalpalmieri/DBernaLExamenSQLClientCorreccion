using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Genero
    {
        int idGenero;
        string nombre;
        List<object> generos;

        public int IdGenero { get => idGenero; set => idGenero = value; }

        [DisplayName("Genero")]
        public string Nombre { get => nombre; set => nombre = value; }
        public List<object> Generos { get => generos; set => generos = value; }
    }
}
