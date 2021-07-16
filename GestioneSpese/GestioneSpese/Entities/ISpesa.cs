using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpese.Entities
{
    public interface ISpesa
    {
        public DateTime Data { get; set; }
        public string Categoria { get; }
        public string Descrizione { get; set; }
        public double Prezzo { get; set; }
        public string Livello { get; set; }

        
    }
}
