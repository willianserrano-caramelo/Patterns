using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.DesignPatterns.BehavioralPatterns.ChainOfResponsibilityPattern.Interfaces
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);
        void HandleRequest(object request);
    }

}
