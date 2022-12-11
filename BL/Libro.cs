using DL;
using ML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Libro
    {
        public static Result GetAll()
        {
            Result result = new Result();

            try
            {
                string query = "LibroGet";
                using (SqlConnection context = new SqlConnection(Conexion.GetConexion()))
                {
                    SqlCommand cmd = new SqlCommand(query, context);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        result.Objects = new List<object>();
                        ML.Libro libro = null;
                        while (reader.Read())
                        {

                            libro = new ML.Libro();
                            libro.Autor = new ML.Autor();
                            libro.Editorial = new ML.Editorial();
                            libro.Genero = new ML.Genero();

                            libro.IdLibro = reader.GetInt32(0);
                            libro.Nombre = reader.GetString(1);
                            libro.Autor.IdAutor = reader.GetInt32(2);
                            libro.NumeroPaginas = reader.GetInt32(3);
                            libro.FechaPublicacion = reader.GetDateTime(4).ToString("dd/MM/yyyy");
                            libro.Editorial.IdEditorial = reader.GetInt32(5);
                            libro.Edicion = reader.GetString(6);
                            libro.Genero.IdGenero = reader.GetInt32(7);

                            libro.Autor.Nombre = reader.GetString(8);
                            libro.Editorial.Nombre = reader.GetString(9);

                            libro.Genero.Nombre = reader.GetString(10);

                            result.Objects.Add(libro);
                        }

                        result.Mensaje = "Información encontrada con éxito";
                        result.Correct = true;

                    }
                    else
                    {
                        result.Mensaje = "Información no encontrada";
                        result.Correct = false;
                    }


                    cmd.Connection.Close();

                }

            }
            catch (Exception error)
            {
                result.Exception = error;
                result.Correct = false;
                result.Mensaje = $"Error: {result.Exception.Message}";
            }

            return result;
        }

        public static Result GetById(int IdLibro)
        {
            Result result = new Result();

            try
            {
                string query = "LibroGet";
                using (SqlConnection context = new SqlConnection(Conexion.GetConexion()))
                {
                    SqlCommand cmd = new SqlCommand(query, context);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection.Open();
                    cmd.Parameters.AddWithValue("@IdLibro", IdLibro);

                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);

                    if (reader.HasRows)
                    {
                        ML.Libro libro = null;
                        reader.Read();

                        libro = new ML.Libro();
                        libro.Autor = new ML.Autor();
                        libro.Editorial = new ML.Editorial();
                        libro.Genero = new ML.Genero();

                        libro.IdLibro = reader.GetInt32(0);
                        libro.Nombre = reader.GetString(1);
                        libro.Autor.IdAutor = reader.GetInt32(2);
                        libro.NumeroPaginas = reader.GetInt32(3);
                        libro.FechaPublicacion = reader.GetDateTime(4).ToString("dd/MM/yyyy");
                        libro.Editorial.IdEditorial = reader.GetInt32(5);
                        libro.Edicion = reader.GetString(6);
                        libro.Genero.IdGenero = reader.GetInt32(7);

                        libro.Autor.Nombre = reader.GetString(8);
                        libro.Editorial.Nombre = reader.GetString(9);

                        libro.Genero.Nombre = reader.GetString(10);

                        result.Object = libro;


                        result.Mensaje = "Información encontrada con éxito";
                        result.Correct = true;

                    }
                    else
                    {
                        result.Mensaje = "Información no encontrada";
                        result.Correct = false;
                    }


                    cmd.Connection.Close();

                }

            }
            catch (Exception error)
            {
                result.Exception = error;
                result.Correct = false;
                result.Mensaje = $"Error: {result.Exception.Message}";
            }

            return result;
        }

        public static Result Add(ML.Libro libro)
        {
            Result result = new Result();

            try
            {
                string query = "LibroAdd";
                using (SqlConnection context = new SqlConnection(Conexion.GetConexion()))
                {
                    SqlCommand cmd = new SqlCommand(query, context);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", libro.Nombre);
                    cmd.Parameters.AddWithValue("@IdAutor", libro.Autor.IdAutor);
                    cmd.Parameters.AddWithValue("@NumeroPaginas", libro.NumeroPaginas);
                    cmd.Parameters.AddWithValue("@FechaPublicacion", libro.FechaPublicacion);
                    cmd.Parameters.AddWithValue("@IdEditorial", libro.Editorial.IdEditorial);
                    cmd.Parameters.AddWithValue("@Edicion", libro.Edicion);
                    cmd.Parameters.AddWithValue("@IdGenero", libro.Genero.IdGenero);

                    cmd.Connection.Open();

                    int execute = cmd.ExecuteNonQuery();


                    if (execute > 0)
                    {

                        result.Mensaje = "Registro Ingresado exitosamente";
                        result.Correct = true;

                    }
                    else
                    {
                        result.Mensaje = "Registro NO ingresado";
                        result.Correct = false;
                    }


                    cmd.Connection.Close();

                }

            }
            catch (Exception error)
            {
                result.Exception = error;
                result.Correct = false;
                result.Mensaje = $"Error: {result.Exception.Message}";
            }

            return result;
        }

        public static Result Update(ML.Libro libro)
        {
            Result result = new Result();

            try
            {
                string query = "LibroUpdate";
                using (SqlConnection context = new SqlConnection(Conexion.GetConexion()))
                {
                    SqlCommand cmd = new SqlCommand(query, context);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdLibro", libro.IdLibro);
                    cmd.Parameters.AddWithValue("@Nombre", libro.Nombre);
                    cmd.Parameters.AddWithValue("@IdAutor", libro.Autor.IdAutor);
                    cmd.Parameters.AddWithValue("@NumeroPaginas", libro.NumeroPaginas);
                    cmd.Parameters.AddWithValue("@FechaPublicacion", libro.FechaPublicacion);
                    cmd.Parameters.AddWithValue("@IdEditorial", libro.Editorial.IdEditorial);
                    cmd.Parameters.AddWithValue("@Edicion", libro.Edicion);
                    cmd.Parameters.AddWithValue("@IdGenero", libro.Genero.IdGenero);

                    cmd.Connection.Open();

                    int execute = cmd.ExecuteNonQuery();


                    if (execute > 0)
                    {

                        result.Mensaje = "Registro Actualizado correctamente exitosamente";
                        result.Correct = true;

                    }
                    else
                    {
                        result.Mensaje = "Registro NO actualizado";
                        result.Correct = false;
                    }


                    cmd.Connection.Close();

                }

            }
            catch (Exception error)
            {
                result.Exception = error;
                result.Correct = false;
                result.Mensaje = $"Error: {result.Exception.Message}";
            }

            return result;
        }


        public static Result Delete(int IdLibro)
        {
            Result result = new Result();

            try
            {
                string query = "LibroDelete";
                using (SqlConnection context = new SqlConnection(Conexion.GetConexion()))
                {
                    SqlCommand cmd = new SqlCommand(query, context);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdLibro", IdLibro);

                    cmd.Connection.Open();

                    int execute = cmd.ExecuteNonQuery();


                    if (execute > 0)
                    {

                        result.Mensaje = "Registro borrado correctamente exitosamente";
                        result.Correct = true;

                    }
                    else
                    {
                        result.Mensaje = "Registro NO borrado";
                        result.Correct = false;
                    }


                    cmd.Connection.Close();

                }

            }
            catch (Exception error)
            {
                result.Exception = error;
                result.Correct = false;
                result.Mensaje = $"Error: {result.Exception.Message}";
            }

            return result;
        }






        public static Result GetAllEF()
        {
            Result result = new Result();

            try
            {
                using (DBernalExamenSQLClientEntities context = new DBernalExamenSQLClientEntities())
                {

                    var execute = context.LibroGet(null).ToList();

                    if (execute.Count > 0)
                    {
                        result.Objects = new List<object>();
                        ML.Libro libro = null;
                        foreach (var item in execute)
                        {

                            libro = new ML.Libro();
                            libro.Autor = new ML.Autor();
                            libro.Editorial = new ML.Editorial();
                            libro.Genero = new ML.Genero();

                            libro.IdLibro = item.IdLibro;
                            libro.Nombre = item.Nombre;
                            libro.Autor.IdAutor = (int)item.IdAutor;
                            libro.NumeroPaginas = (int)item.NumeroPaginas;
                            libro.FechaPublicacion = item.FechaPublicacion.ToString();
                            libro.Editorial.IdEditorial = (int)item.IdEditorial;
                            libro.Edicion = item.Edicion;
                            libro.Genero.IdGenero = (int)item.IdGenero;

                            libro.Autor.Nombre = item.AutorNombre;
                            libro.Editorial.Nombre = item.EditorialNombre;

                            libro.Genero.Nombre = item.GeneroNombre;
                            result.Objects.Add(libro);
                        }

                        result.Mensaje = "Información encontrada con éxito";
                        result.Correct = true;

                    }
                    else
                    {
                        result.Mensaje = "Información no encontrada";
                        result.Correct = false;
                    }


                }

            }
            catch (Exception error)
            {
                result.Exception = error;
                result.Correct = false;
                result.Mensaje = $"Error: {result.Exception.Message}";
            }

            return result;
        }

        public static Result GetByIdEF(int IdLibro)
        {
            Result result = new Result();

            try
            {
                using (DBernalExamenSQLClientEntities context = new DBernalExamenSQLClientEntities())
                {
                    var execute = context.LibroGet(IdLibro).SingleOrDefault();

                    if (execute != null)
                    {
                        ML.Libro libro = new ML.Libro();
                        libro.Autor = new ML.Autor();
                        libro.Editorial = new ML.Editorial();
                        libro.Genero = new ML.Genero();

                        libro.IdLibro = execute.IdLibro;
                        libro.Nombre = execute.Nombre;
                        libro.Autor.IdAutor = (int)execute.IdAutor;
                        libro.NumeroPaginas = (int)execute.NumeroPaginas;
                        libro.FechaPublicacion = execute.FechaPublicacion.ToString();
                        libro.Editorial.IdEditorial = (int)execute.IdEditorial;
                        libro.Edicion = execute.Edicion;
                        libro.Genero.IdGenero = (int)execute.IdGenero;

                        libro.Autor.Nombre = execute.AutorNombre;
                        libro.Editorial.Nombre = execute.EditorialNombre;

                        libro.Genero.Nombre = execute.GeneroNombre;
                        result.Object = libro;


                        result.Mensaje = "Información encontrada con éxito";
                        result.Correct = true;

                    }
                    else
                    {
                        result.Mensaje = "Información no encontrada";
                        result.Correct = false;
                    }


                }

            }
            catch (Exception error)
            {
                result.Exception = error;
                result.Correct = false;
                result.Mensaje = $"Error: {result.Exception.Message}";
            }

            return result;
        }

        public static Result AddEF(ML.Libro libro)
        {
            Result result = new Result();

            try
            {
                string query = "LibroAdd";
                using (DBernalExamenSQLClientEntities context = new DBernalExamenSQLClientEntities())
                {

                    int execute = context.LibroAdd(
                        libro.Nombre, 
                        libro.Autor.IdAutor, 
                        libro.NumeroPaginas, 
                        libro.FechaPublicacion, 
                        libro.Editorial.IdEditorial, 
                        libro.Edicion, 
                        libro.Genero.IdGenero);


                    if (execute > 0)
                    {

                        result.Mensaje = "Registro Ingresado exitosamente";
                        result.Correct = true;

                    }
                    else
                    {
                        result.Mensaje = "Registro NO ingresado";
                        result.Correct = false;
                    }


                }

            }
            catch (Exception error)
            {
                result.Exception = error;
                result.Correct = false;
                result.Mensaje = $"Error: {result.Exception.Message}";
            }

            return result;
        }

        public static Result UpdateEF(ML.Libro libro)
        {
            Result result = new Result();

            try
            {
                using (DBernalExamenSQLClientEntities context = new DBernalExamenSQLClientEntities())
                {
                    int execute = context.LibroUpdate(
                     libro.IdLibro,
                     libro.Nombre,
                     libro.Autor.IdAutor,
                     libro.NumeroPaginas,
                     libro.FechaPublicacion,
                     libro.Editorial.IdEditorial,
                     libro.Edicion,
                     libro.Genero.IdGenero);


                    if (execute > 0)
                    {

                        result.Mensaje = "Registro Actualizado correctamente exitosamente";
                        result.Correct = true;

                    }
                    else
                    {
                        result.Mensaje = "Registro NO actualizado";
                        result.Correct = false;
                    }


                }

            }
            catch (Exception error)
            {
                result.Exception = error;
                result.Correct = false;
                result.Mensaje = $"Error: {result.Exception.Message}";
            }

            return result;
        }


        public static Result DeleteEF(int IdLibro)
        {
            Result result = new Result();

            try
            { 
                using (DBernalExamenSQLClientEntities context = new DBernalExamenSQLClientEntities())
                {
                    int execute = context.LibroDelete(IdLibro);


                    if (execute > 0)
                    {

                        result.Mensaje = "Registro borrado correctamente exitosamente";
                        result.Correct = true;

                    }
                    else
                    {
                        result.Mensaje = "Registro NO borrado";
                        result.Correct = false;
                    }


                }

            }
            catch (Exception error)
            {
                result.Exception = error;
                result.Correct = false;
                result.Mensaje = $"Error: {result.Exception.Message}";
            }

            return result;
        }
    }
}
