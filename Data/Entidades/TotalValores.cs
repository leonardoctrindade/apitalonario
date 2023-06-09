﻿using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class TotalValores
    {
        public string Nome { get; set; }

        public int Total { get; set; }

        public int Matricula { get; set; }

        public DateTime DataInclusao { get; set; }
    }
}
