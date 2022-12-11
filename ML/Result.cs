using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Result
    {
        bool correct;
        object _object;
        List<object> objects;
        Exception exception;
        string mensaje;

        public bool Correct { get => correct; set => correct = value; }
        public object Object { get => _object; set => _object = value; }
        public List<object> Objects { get => objects; set => objects = value; }
        public Exception Exception { get => exception; set => exception = value; }
        public string Mensaje { get => mensaje; set => mensaje = value; }
    }
}
