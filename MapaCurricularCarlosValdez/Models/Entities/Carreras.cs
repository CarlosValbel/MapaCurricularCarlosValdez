﻿using System;
using System.Collections.Generic;

namespace MapaCurricularCarlosValdez.Models.Entities;

public partial class Carreras
{
    public int Id { get; set; }

    public string Clave { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Plan { get; set; } = null!;

    public string Especialidad { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Materias> Materias { get; set; } = new List<Materias>();
}
