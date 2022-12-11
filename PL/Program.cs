using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;


namespace PL
{
    internal class Program
    {


        static void Main(string[] args)
        {



            do
            {

                printTable();
                cw.print($"Selecciona una opción: ");
                string text = Console.ReadLine();
                int opcion = int.TryParse(text, out _) ? int.Parse(text) : 0;

                Redireccionar(opcion);

                Console.ReadKey();

            } while (true);

        }

      

        static void Redireccionar(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    {
                        Libro.GetAll();
                        break;
                    }
                case 2:
                    {
                        Libro.Add();
                        break;
                    }
                case 3:
                    {
                        Libro.Update();
                        break;
                    }
                case 4:
                    {
                        Libro.Delete();
                        break;
                    }
                case 5:
                    {
                        Libro.GetById();
                        break;
                    }
                case 6:
                    {
                        Environment.Exit(0);
                        break;
                    }
                default:
                    Console.WriteLine("Opción Invalida");
                    break;
            }
        }

        static void printTable()
        {
            cw.printLine("Menu");
            List<string> values = new List<string> { "1", "2", "3", "4", "5", "6" };
            List<string> optios = new List<string> { "Get All", "Add", "Update", "Delete", "GetById", "Salir" };
            var table = new ConsoleTable(values.ToArray());
            table.AddRow(optios.ToArray());

            table.Write(Format.Alternative);
            

        }

    }


    public class cw
    {
        public static Action<string> print = (string text) =>
        {
            Console.Write(text);
        };

        public static Action<string> printLine = (string text) =>
        {
            Console.WriteLine(text);
        };
    }
}
