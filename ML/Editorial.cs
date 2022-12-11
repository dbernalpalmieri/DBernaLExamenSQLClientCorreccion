using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Editorial
    {
        int idEditorial;
        string nombre;
        List<object> editoriales;

        public int IdEditorial { get => idEditorial; set => idEditorial = value; }

        [DisplayName("Editorial")]
        public string Nombre { get => nombre; set => nombre = value; }
        public List<object> Editoriales { get => editoriales; set => editoriales = value; }
    }
}
