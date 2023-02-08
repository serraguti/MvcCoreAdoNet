using Microsoft.AspNetCore.Mvc;
using MvcCoreAdoNet.Models;
using MvcCoreAdoNet.Repositories;

namespace MvcCoreAdoNet.Controllers
{
    public class DoctoresController : Controller
    {
        private RepositoryDoctores repo;

        public DoctoresController()
        {
            this.repo = new RepositoryDoctores();
        }

        public IActionResult DoctoresEspecialidad()
        {
            List<Doctor> doctores = this.repo.GetDoctores();
            List<string> especialidades =
                this.repo.GetEspecialidades();
            DatosDoctores modelDatos = new DatosDoctores();
            modelDatos.Especialidades = especialidades;
            modelDatos.Doctores = doctores;
            return View(modelDatos);
        }

        [HttpPost]
        public IActionResult DoctoresEspecialidad(string especialidad)
        {
            List<Doctor> doctores =
                this.repo.GetDoctoresEspecialidad(especialidad);
            return View(doctores);
        }
    }
}
