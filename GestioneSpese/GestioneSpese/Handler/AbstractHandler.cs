using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpese.Handler
{
    public abstract class AbstractHandler : IHandler
    {
        private IHandler _nextHandler;

        public virtual string Handle(double prezzo)
        {
            if (this._nextHandler != null) //se non sono arrivata alla fine della catena
            {
                return this._nextHandler.Handle(prezzo);

            }
            else
            {
                return $"Spesa non approvata";
            }
        }

        public IHandler SetNext(IHandler handler)
        {
            this._nextHandler = handler;
            return handler;
        }
    }
}
