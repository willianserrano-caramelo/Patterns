using Patterns.DesignPatterns.BehavioralPatterns.ObserverPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.DesignPatterns.BehavioralPatterns.ObserverPattern
{
    public class ConcreteObserverB : IObserver
    {
        public void Update(string message)
        {
            Console.WriteLine($"Observer B recebeu a mensagem: {message}");
        }
    }
}
