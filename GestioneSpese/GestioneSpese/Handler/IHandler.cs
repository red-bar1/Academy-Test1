using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpese.Handler
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);
        string Handle(double prezzo);
    }
}
