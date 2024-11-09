using MapaCurricularCarlosValdez.Models.Entities;

namespace MapaCurricularCarlosValdez.Models.ViewModels
{
	public class ReticulaViewModel
	{
		public string Carrera { get; set; } = "";
		public string Plan { get; set; } = "";
		public int CreditosTotales { get; set; }
		public IEnumerable<Materias>[] Semestres { get; set; }

		public ReticulaViewModel()
		{
			Semestres = new IEnumerable<Materias>[9];
		}
	}
}
