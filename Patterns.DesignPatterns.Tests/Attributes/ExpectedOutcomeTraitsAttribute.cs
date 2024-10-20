using Patterns.DesignPatterns.Tests.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Patterns.DesignPatterns.Tests.Attributes
{
    [TraitDiscoverer("Patterns.DesignPatterns.Tests.Discoverers.ExpectedOutcomeTraitsDiscoverer", "Patterns.DesignPatterns.Tests")]
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public sealed class ExpectedOutcomeTraitsAttribute : Attribute, ITraitAttribute
    {
        public TraitExpectedOutcome Value { get; }

        public ExpectedOutcomeTraitsAttribute(TraitExpectedOutcome value)
        {
            Value = value;
        }
    }    
}
