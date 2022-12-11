using BL;
using ConsoleTables;
using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Libro
    {
        public static void GetAll()
        {
            ML.Result result = BL.Libro.GetAll();

            if (result.Correct)
            {
                PrintResult(result);
            }
            else
            {
                Error(result.Mensaje);
            }

        }

        public static void GetById()
        {
            ML.Libro libro = new ML.Libro();
            Console.Write("Id Libro: ");
            libro.IdLibro = int.Parse(Console.ReadLine());

            ML.Result result = BL.Libro.GetById(libro.IdLibro);

            if (result.Correct)
            {
                PrintResult(result);
            }
            else
            {
                Error(result.Mensaje);
            }

        }

        public static void Add()
        {
            ML.Libro libro = new ML.Libro();
            libro.Autor = new ML.Autor();
            libro.Editorial = new ML.Editorial();
            libro.Genero = new ML.Genero();

            Console.Write("Nombre: ");
            libro.Nombre = Console.ReadLine();
           
            Console.Write("Id Autor: ");
            libro.Autor.IdAutor = int.Parse(Console.ReadLine());
            
            Console.Write("Numero Paginas: ");
            libro.NumeroPaginas = int.Parse(Console.ReadLine());
            
            Console.Write("Fecha publicación (dd/MM/yyyy): ");
            libro.FechaPublicacion = Console.ReadLine();
            
            Console.Write("Id Editorial: ");
            libro.Editorial.IdEditorial = int.Parse(Console.ReadLine());
            
            Console.Write("Edición: ");
            libro.Edicion = Console.ReadLine();
            
            Console.Write("Id Genero: ");
            libro.Genero.IdGenero = int.Parse(Console.ReadLine());

            ML.Result result = BL.Libro.Add(libro);

            if (result.Correct)
            {
                cw.printLine(result.Mensaje);

            }
            else
            {
                Error(result.Mensaje);
            }

        }

        public static void Update()
        {
            ML.Libro libro = new ML.Libro();
            libro.Autor = new ML.Autor();
            libro.Editorial = new ML.Editorial();
            libro.Genero = new ML.Genero();

            Console.Write("Id Libro: ");
            libro.IdLibro = int.Parse(Console.ReadLine());

            ML.Result result = BL.Libro.GetById(libro.IdLibro);

            if (result.Correct)
            {
                PrintResult(result);

                Console.Write("Nombre: ");
                libro.Nombre = Console.ReadLine();
                Console.Write("Id Autor: ");
                libro.Autor.IdAutor = int.Parse(Console.ReadLine());
                Console.Write("Numero Paginas: ");
                libro.NumeroPaginas = int.Parse(Console.ReadLine());
                Console.Write("Fecha publicación (dd/MM/yyyy): ");
                libro.FechaPublicacion = Console.ReadLine();
                Console.Write("Id Editorial: ");
                libro.Editorial.IdEditorial = int.Parse(Console.ReadLine());
                Console.Write("Edición: ");
                libro.Edicion = Console.ReadLine();
                Console.Write("Id Genero: ");
                libro.Genero.IdGenero = int.Parse(Console.ReadLine());

                result = BL.Libro.Update(libro);

                if (result.Correct)
                {
                    Console.WriteLine(result.Mensaje);
                    PrintResult(result = BL.Libro.GetById(libro.IdLibro));
                }
                else
                {
                    Error(result.Mensaje);
                }

            }
            else
            {
                Error(result.Mensaje);
            }
        }

        public static void Delete()
        {
            ML.Libro libro = new ML.Libro();

            Console.Write("Id Libro: ");
            libro.IdLibro = int.Parse(Console.ReadLine());
            ML.Result result = BL.Libro.GetById(libro.IdLibro);

            if (result.Correct)
            {
                PrintResult(result);

                cw.print("¿Eliminar Registro (S/N)? ");
                string opcion = Console.ReadLine().ToLower();
                if (opcion.Equals("s"))
                {
                    result = BL.Libro.Delete(libro.IdLibro);

                    if (result.Correct)
                    {
                        cw.printLine(result.Mensaje);
                    }
                    else
                    {
                        Error(result.Mensaje);
                    }
                }
                else
                {
                    cw.printLine("Ninguna acción realizada");
                }
            }
            else
            {
                Error(result.Mensaje);
            }


        }
        static void Error(string mensaje)
        {
            cw.printLine(mensaje);
        }

        static void PrintResult(Result result)
        {

            Console.WriteLine(result.Mensaje);

            List<string> headers = new List<string> { "ID", "Nombre", "Autor", "Paginas", "Lanzamiento", "Editorial", "Edición", "Genero" };
            var table = new ConsoleTable(headers.ToArray());

            ML.Libro libro;

            if (result.Objects != null)
            {

                result.Objects.ForEach(obj =>
                {
                    libro = (ML.Libro)obj;
                    table.AddRow(libro.IdLibro, libro.Nombre, libro.Autor.Nombre, libro.NumeroPaginas, libro.FechaPublicacion, libro.Editorial.Nombre, libro.Edicion, libro.Genero.Nombre);
                });

            }
            else if (result.Object != null)
            {
                libro = (ML.Libro)result.Object;
                table.AddRow(libro.IdLibro, libro.Nombre, libro.Autor.Nombre, libro.NumeroPaginas, libro.FechaPublicacion, libro.Editorial.Nombre, libro.Edicion, libro.Genero.Nombre);

            }
            table.Write(Format.Alternative);


        }



    }
}
