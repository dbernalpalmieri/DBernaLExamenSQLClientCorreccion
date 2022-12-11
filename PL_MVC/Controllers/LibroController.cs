using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class LibroController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result result = BL.Libro.GetAllEF();
            ML.Libro libro = new ML.Libro();
            
            if (result.Correct)
            {
                libro.Libros = result.Objects;
            }
            else
            {
                libro.Libros = new List<object>();
            }
            return View(libro);
        }

        public ActionResult Delete(int? IdLibro)
        {
            if (IdLibro != null)
            {

                Result resultLibro = BL.Libro.DeleteEF(IdLibro.Value);
                ViewBag.Message = resultLibro.Mensaje;
            }
            else
            {
                ViewBag.Message = "La información es invalida.";
            }
            return PartialView("Modal");
        }

        [HttpGet]
        public ActionResult Form(int? IdLibro)
        {
            ML.Libro libro = new ML.Libro();
            // Revisamos si es Add or Update
            if (IdLibro != null)
            {
                //Update
                Result resultLibro = BL.Libro.GetByIdEF(IdLibro.Value);
                if(resultLibro.Correct && resultLibro.Object != null)
                {
                    libro = (ML.Libro)resultLibro.Object;
                }
            }
            else
            {
                libro.Autor = new ML.Autor();
                libro.Editorial = new ML.Editorial();
                libro.Genero = new ML.Genero();
            }


            // Cargar la información para los DropDownList

            Result resultEditoriales = BL.Editorial.GetAll();
            Result resultAutores = BL.Autor.GetAll();
            Result resultGeneros = BL.Genero.GetAll();

            if (resultEditoriales.Correct && resultAutores.Correct && resultGeneros.Correct)
            {
                libro.Autor.Autores = resultAutores.Objects;
                libro.Editorial.Editoriales = resultEditoriales.Objects;
                libro.Genero.Generos = resultGeneros.Objects;
            }
            else
            {
                libro.Autor.Autores = new List<object> { };
                libro.Editorial.Editoriales = new List<object> { };
                libro.Genero.Generos = new List<object> { };
            }
            return View(libro);
        }


        [HttpPost]
        public ActionResult Form(ML.Libro libro)
        {
            if(libro != null)
            {
                ML.Result resultQuery;

                // Revisamos si es Add or Update
                if (libro.IdLibro == 0)
                {
                    //Add
                    resultQuery = BL.Libro.AddEF(libro);

                }
                else
                {
                    //Update
                    resultQuery = BL.Libro.UpdateEF(libro);
                }

                ViewBag.Message = resultQuery.Mensaje;
            }
            else
            {
                ViewBag.Message = "La información dada está incompleta.";
            }

            return PartialView("Modal");

        }
    }
}