using DL;
using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Autor
    {
        public static Result GetAll()
        {
            Result result = new Result();
            try
            {
                using (DBernalExamenSQLClientEntities context = new DBernalExamenSQLClientEntities())
                {
                    var execute = context.AutorGet(null).ToList();
                    if (execute.Count > 0)
                    {
                        result.Objects = new List<object>();
                        ML.Autor autor;

                        foreach (var item in execute)
                        {
                            autor = new ML.Autor
                            {
                                IdAutor = item.IdAutor,
                                Nombre = item.Nombre,
                            };


                            result.Objects.Add(autor);
                        }
                        result.Correct = true;
                        result.Mensaje = $"Información obtenida con éxito de la base de datos";
                    }
                    else
                    {
                        result.Correct = false;
                        result.Mensaje = "Información no encontrada";
                    }
                }
            }
            catch (Exception error)
            {
                result.Exception = error;
                result.Mensaje = $"Error: {result.Exception.Message}";
                result.Correct = false;
            }
            return result;
        }
    }
}
