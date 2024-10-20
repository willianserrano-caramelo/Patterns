using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.DesignPatterns.Exceptions
{
    public class NegativeNumberException : Exception
    {
        public NegativeNumberException() : base("Erro: Números negativos não são permitidos.") { }
    }
}
