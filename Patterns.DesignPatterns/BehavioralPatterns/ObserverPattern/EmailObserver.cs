using Patterns.DesignPatterns.BehavioralPatterns.ObserverPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.DesignPatterns.BehavioralPatterns.ObserverPattern
{
    public class EmailObserver : IPlataformaObserver
    {
        public void Atualizar(string noticia)
        {
            Console.WriteLine($"Notificação por E-mail: {noticia}");
        }
    }
}
