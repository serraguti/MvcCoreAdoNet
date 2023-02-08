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
            ViewData["ESPECIALIDADES"] = especialidades;
            return View(doctores);
        }

        [HttpPost]
        public IActionResult DoctoresEspecialidad(string especialidad)
        {
            List<Doctor> doctores =
                this.repo.GetDoctoresEspecialidad(especialidad);
            List<string> especialidades =
                this.repo.GetEspecialidades();
            ViewData["ESPECIALIDADES"] = especialidades;
            return View(doctores);
        }
    }
}
