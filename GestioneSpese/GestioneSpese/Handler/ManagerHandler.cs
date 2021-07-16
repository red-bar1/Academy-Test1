using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpese.Handler
{
    public class ManagerHandler : AbstractHandler
    {
        public override string Handle(double prezzo)
        {
            if (prezzo <= 400)
            {
                return $"Una spesa è stata approvata dal Manager";
            }
            else
            {
                return base.Handle(prezzo);
            }
        }
    }
}
