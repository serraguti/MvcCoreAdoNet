using Microsoft.AspNetCore.Mvc;
using MvcCoreAdoNet.Models;
using MvcCoreAdoNet.Repositories;

namespace MvcCoreAdoNet.Controllers
{
    public class DoctoresController : Controller
    {
        private RepositoryDoctores repoDoctores;
        private RepositoryHospital repoHospital;

        public DoctoresController()
        {
            this.repoDoctores = new RepositoryDoctores();
            this.repoHospital = new RepositoryHospital();
        }

        public IActionResult DoctoresEspecialidad()
        {
            List<Doctor> doctores = this.repoDoctores.GetDoctores();
            List<string> especialidades =
                this.repoDoctores.GetEspecialidades();
            ViewData["ESPECIALIDADES"] = especialidades;
            return View(doctores);
        }

        [HttpPost]
        public IActionResult DoctoresEspecialidad(string especialidad)
        {
            List<Doctor> doctores =
                this.repoDoctores.GetDoctoresEspecialidad(especialidad);
            List<string> especialidades =
                this.repoDoctores.GetEspecialidades();
            ViewData["ESPECIALIDADES"] = especialidades;
            return View(doctores);
        }

        public IActionResult DoctoresHospital()
        {
            List<Hospital> hospitales =
                this.repoHospital.GetHospitales();
            ViewData["HOSPITALES"] = hospitales;
            return View();
        }

        [HttpPost]
        public IActionResult DoctoresHospital(int idhospital)
        {
            List<Hospital> hospitales = this.repoHospital.GetHospitales();
            List<Doctor> doctores = 
                this.repoDoctores.GetDoctoresHospital(idhospital);
            ViewData["HOSPITALES"] = hospitales;
            return View(doctores);
        }
    }
}
