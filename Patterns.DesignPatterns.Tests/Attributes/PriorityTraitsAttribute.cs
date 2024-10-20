using Patterns.DesignPatterns.Tests.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace Patterns.DesignPatterns.Tests.Attributes
{
    [TraitDiscoverer("Patterns.DesignPatterns.Tests.Discoverers.PriorityTraitsDiscoverer", "Patterns.DesignPatterns.Tests")]
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public sealed class PriorityTraitsAttribute : Attribute, ITraitAttribute
    {
        public TraitPriority Value { get; }

        public PriorityTraitsAttribute(TraitPriority value)
        {
            Value = value;
        }
    }
}
