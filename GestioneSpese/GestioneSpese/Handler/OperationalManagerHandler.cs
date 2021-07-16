using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpese.Handler
{
    public class OperationalManagerHandler : AbstractHandler
    {
        public override string Handle(double prezzo)
        {
            if (prezzo <= 1000)
            {
                return $"Una spesa è stata approvata dall' Operational Manager";
            }
            else
            {
                return base.Handle(prezzo);
            }
        }
    }
}
