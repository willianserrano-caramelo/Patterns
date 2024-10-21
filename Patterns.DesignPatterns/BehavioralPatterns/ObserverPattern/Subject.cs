using Logger;
using Logger.Interfaces;
using Patterns.DesignPatterns.BehavioralPatterns.ObserverPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.DesignPatterns.BehavioralPatterns.ObserverPattern
{
    public class Subject : ISubject
    {
        private readonly List<IObserver> _observers = new();
        private readonly ILogger _logger;
        private string _message;

        public Subject(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void RegisterObserver(IObserver observer)
        {
            _observers.Add(observer);
            _logger.LogInfo($"Observer registrado: {observer.GetType().Name}");
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
            _logger.LogInfo($"Observer removido: {observer.GetType().Name}");
        }

        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                _logger.LogInfo($"Notificando observer: {observer.GetType().Name} com a mensagem: {_message}");
                observer.Update(_message);
            }
        }

        public void ChangeMessage(string message)
        {
            _message = message;
            _logger.LogInfo($"Mensagem alterada: {message}");
            NotifyObservers();
        }
    }
}
