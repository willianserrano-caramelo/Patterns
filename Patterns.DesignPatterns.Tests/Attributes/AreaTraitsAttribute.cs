using Patterns.DesignPatterns.Tests.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace Patterns.DesignPatterns.Tests.Attributes
{
    [TraitDiscoverer("Patterns.DesignPatterns.Tests.Discoverers.AreaTraitsDiscoverer", "Patterns.DesignPatterns.Tests")]
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public sealed class AreaTraitsAttribute : Attribute, ITraitAttribute
    {
        public TraitArea Value { get; }

        public AreaTraitsAttribute(TraitArea value)
        {
            Value = value;
        }
    }
}
