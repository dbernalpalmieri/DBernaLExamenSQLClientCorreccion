using DL;
using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Genero
    {
        public static Result GetAll()
        {
            Result result = new Result();
            try
            {
                using (DBernalExamenSQLClientEntities context = new DBernalExamenSQLClientEntities())
                {
                    var execute = context.GeneroGet(null).ToList();
                    if (execute.Count > 0)
                    {
                        result.Objects = new List<object>();
                        ML.Genero genero;

                        foreach (var item in execute)
                        {
                            genero = new ML.Genero
                            {
                                IdGenero = item.IdGenero,
                                Nombre = item.Nombre,
                            };


                            result.Objects.Add(genero);
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
