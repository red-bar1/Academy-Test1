using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpese.Handler
{
    public class CEOHandler : AbstractHandler
    {
        public override string Handle(double prezzo)
        {
            if (prezzo > 1000 && prezzo <2500)
            {
                return $"Una spesa è stata approvata dal CEO";
            }
            else
            {
                return base.Handle(prezzo);
            }
        }
    }
}
