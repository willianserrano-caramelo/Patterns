using Patterns.DesignPatterns.BehavioralPatterns.ObserverPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.DesignPatterns.BehavioralPatterns.ObserverPattern
{
    public class NotificadorDeNoticias : INotificadorDeNoticias
    {
        private readonly List<IPlataformaObserver> _plataformas = new();
        private string _noticia;

        public void RegistrarPlataforma(IPlataformaObserver plataforma)
        {
            _plataformas.Add(plataforma);
        }

        public void RemoverPlataforma(IPlataformaObserver plataforma)
        {
            _plataformas.Remove(plataforma);
        }

        public void NotificarPlataformas()
        {
            foreach (var plataforma in _plataformas)
            {
                plataforma.Atualizar(_noticia);
            }
        }

        public void NovaNoticia(string noticia)
        {
            _noticia = noticia;
            NotificarPlataformas();
        }
    }
}
