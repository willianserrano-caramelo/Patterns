using Patterns.DesignPatterns.BehavioralPatterns.IteratorPattern.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.DesignPatterns.BehavioralPatterns.IteratorPattern.Interfaces
{
    public interface IMusicIterator
    {
        bool HasNext();
        Song Next();
    }
}
