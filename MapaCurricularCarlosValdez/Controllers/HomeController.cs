using MapaCurricularCarlosValdez.Models.Entities;
using MapaCurricularCarlosValdez.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MapaCurricularCarlosValdez.Controllers
{
    public class HomeController : Controller
    {
		MapaCurricularContext contenedor = new();

		[Route("/")]
		public IActionResult Index()
		{
			var carreras = contenedor.Carreras.OrderBy(x => x.Nombre).Select(x => new IndexViewModel
			{
				Nombre = x.Nombre,
				Plan = x.Plan
			});
			return View(carreras);
		}

		[Route("{id}")]
		public IActionResult info(string id)
		{
			if (string.IsNullOrWhiteSpace(id))
			{
				return RedirectToAction("Index");
			}
			id = id.Replace("-", " ");
			var carrera = contenedor.Carreras.FirstOrDefault(x => x.Nombre == id);
			if (carrera == null)
			{
				return RedirectToAction("Index");

			}
			return View(carrera);

		}

		[Route("{id}/Reticula")]
		public IActionResult mapa(string id)
		{
			if (string.IsNullOrWhiteSpace(id))
			{
				return RedirectToAction("Index"); 
			}
			id = id.Replace("-", " ");
			var carrera = contenedor.Carreras.Include(x => x.Materias).FirstOrDefault(x => x.Nombre == id);

			if (carrera == null)
			{
				return RedirectToAction("Index");
			}

			ReticulaViewModel vm = new();
			vm.Carrera = carrera.Nombre;
			vm.Plan = carrera.Plan;
			vm.CreditosTotales = carrera.Materias.Sum(x => x.Creditos);

			for (int i = 0; i < 9; i++)
			{
				vm.Semestres[i] = carrera.Materias.Where(x => x.Semestre == i + 1).ToList();
			}


			return View(vm);
		}
	}
}
