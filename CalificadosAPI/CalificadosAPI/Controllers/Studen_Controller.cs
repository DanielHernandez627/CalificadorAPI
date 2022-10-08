using CalificadosAPI.Controllers.LogicControllers;
using Microsoft.AspNetCore.Mvc;
using CalificadosAPI.Models;

namespace CalificadosAPI.Controllers
{
    [ApiController]
    [Route("Studen")]
    public class Studen_Controller : Controller
    {
        StudentsLogic students = new StudentsLogic();

        [HttpPost]
        [Route("general")]
        public dynamic General_Studen()
        {
            dynamic datos = students.obtenerEstudiantes();

            return datos;
        }

        [HttpPost]
        [Route("maxnote")]
        public dynamic MaxNote_Studen()
        {
            dynamic datos = students.obtenerMejorNota();

            return datos;
        }

        [HttpPost]
        [Route("minnote")]
        public dynamic MinNote_Studen()
        {
            dynamic datos = students.obtenerPeorNota();

            return datos;
        }

        [HttpPost]
        [Route("aprove")]
        public dynamic Aprove_Studen()
        {
            dynamic datos = students.obtenerAprobados();

            return datos;
        }

        [HttpPost]
        [Route("notaprove")]
        public dynamic Notaprove_Studen()
        {
            dynamic datos = students.obtenerNoAprobados();

            return datos;
        }

        [HttpPost]
        [Route("students")]
        public dynamic Students()
        {
            dynamic datos = students.obtenerDataEstudiantes();

            return datos;
        }


        [HttpGet]
        [Route("getStudent/{id}")]
        public dynamic obtenerEstudiante(int id)
        {
            dynamic listaEstudiante = students.getStudent(id);
            return listaEstudiante;
        }


        [HttpPut]
        [Route("Update_notes")]
        public bool actualizarNotas([FromBody] Nota nota)
        {
            bool result = students.upDateNotes(nota.id, nota.Calificacion, nota.Descripcion, nota.Id_estudiante);
            return result;
        }
    }
}
