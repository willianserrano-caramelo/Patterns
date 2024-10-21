using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.DesignPatterns.BehavioralPatterns.ObserverPattern.Interfaces
{
    public interface INotificadorDeNoticias
    {
        void RegistrarPlataforma(IPlataformaObserver plataforma);
        void RemoverPlataforma(IPlataformaObserver plataforma);
        void NotificarPlataformas();
    }
}
