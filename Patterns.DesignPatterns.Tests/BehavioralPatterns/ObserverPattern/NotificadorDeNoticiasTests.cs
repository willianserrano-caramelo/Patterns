using Patterns.DesignPatterns.BehavioralPatterns.ObserverPattern;
using Patterns.DesignPatterns.Tests.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.DesignPatterns.Tests.BehavioralPatterns.ObserverPattern
{
    public class NotificadorDeNoticiasTests
    {
        [Fact]
        [TypeTraits(Enums.TraitType.Unit)]
        [PatternTraits(Enums.TraitPattern.Observer)]
        [PriorityTraits(Enums.TraitPriority.High)]
        [ExpectedOutcomeTraits(Enums.TraitExpectedOutcome.Success)]
        public void Deve_NotificarTodasPlataformas_QuandoNovaNoticiaForPublicada()
        {
            // Arrange
            var notificador = new NotificadorDeNoticias();
            var appMovel = new AppMovelObserver();
            var site = new SiteObserver();
            var email = new EmailObserver();

            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            notificador.RegistrarPlataforma(appMovel);
            notificador.RegistrarPlataforma(site);
            notificador.RegistrarPlataforma(email);
            notificador.NovaNoticia("Notícia Urgente!");

            // Aguarda brevemente para garantir a conclusão da escrita
            Thread.Sleep(200);
            // Força a escrita do buffer no console
            Console.Out.Flush();

            // Assert
            var consoleOutput = output.ToString();
            Assert.Contains("Notificação no App Móvel: Notícia Urgente!", consoleOutput);
            Assert.Contains("Notificação no Site: Notícia Urgente!", consoleOutput);
            Assert.Contains("Notificação por E-mail: Notícia Urgente!", consoleOutput);
        }

        [Fact]
        [TypeTraits(Enums.TraitType.Unit)]
        [PatternTraits(Enums.TraitPattern.Observer)]
        [PriorityTraits(Enums.TraitPriority.Medium)]
        [ExpectedOutcomeTraits(Enums.TraitExpectedOutcome.Success)]
        public void Deve_RemoverPlataformaENotificarSomenteRestantes_QuandoNovaNoticiaForPublicada()
        {
            // Arrange
            var notificador = new NotificadorDeNoticias();
            var appMovel = new AppMovelObserver();
            var site = new SiteObserver();
            var email = new EmailObserver();

            var output = new StringWriter();
            Console.SetOut(output);

            notificador.RegistrarPlataforma(appMovel);
            notificador.RegistrarPlataforma(site);
            notificador.RegistrarPlataforma(email);

            // Act
            notificador.RemoverPlataforma(appMovel);
            notificador.NovaNoticia("Notícia Atualizada!");

            // Assert
            var consoleOutput = output.ToString();
            Assert.DoesNotContain("Notificação no App Móvel", consoleOutput);
            Assert.Contains("Notificação no Site: Notícia Atualizada!", consoleOutput);
            Assert.Contains("Notificação por E-mail: Notícia Atualizada!", consoleOutput);
        }
    }
}
