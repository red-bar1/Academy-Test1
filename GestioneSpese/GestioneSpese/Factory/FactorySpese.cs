using GestioneSpese.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpese.Factory
{
    class FactorySpese
    {
        public List<double> GetRimborso(List<ISpesa> speseApprovate)
        {

            List<double> rimborsi = null;
            foreach(var item in speseApprovate)
            {
                if (item.Categoria.Equals("Viaggio"))
                {
                    double rimborso = item.Prezzo + 50;
                    rimborsi.Add(rimborso);
                }
                else if (item.Categoria.Equals("Alloggio"))
                {
                     double rimborso = item.Prezzo;
                    rimborsi.Add(rimborso);
                }
                else if (item.Categoria.Equals("Vitto"))
                {
                     double rimborso = item.Prezzo * 70 / 100;
                    rimborsi.Add(rimborso);
                }
                else
                {
                    double rimborso = item.Prezzo * 10 / 100;
                    rimborsi.Add(rimborso);
                }
                
            }
            return rimborsi;

        }
    }
}
