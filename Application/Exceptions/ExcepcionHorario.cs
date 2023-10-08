using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class ExcepcionHorario : Exception
    {
        public ExcepcionHorario(string message) : base(message) { }
    }
}
