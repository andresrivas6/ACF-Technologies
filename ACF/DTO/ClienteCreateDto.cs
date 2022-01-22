﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACF.DTO
{
    public class ClienteCreateDto
    {
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public int Edad { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}
