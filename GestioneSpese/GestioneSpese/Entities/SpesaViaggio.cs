﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpese.Entities
{
    class SpesaViaggio : ISpesa
    {
        public DateTime Data { get; set; }

        public string Categoria => "Viaggio";

        public string Descrizione { get; set; }
        public double Prezzo { get; set; }
        public string Livello { get; set; }

        public override string ToString()
        {
            return $"Categoria: {Categoria} - Data: {Data.ToShortDateString()} - Descrizione: {Descrizione} - Prezzo: {Prezzo}";
        }
    }
}
