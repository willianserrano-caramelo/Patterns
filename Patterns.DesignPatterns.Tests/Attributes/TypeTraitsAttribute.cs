using Patterns.DesignPatterns.Tests.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace Patterns.DesignPatterns.Tests.Attributes
{
    [TraitDiscoverer("Patterns.DesignPatterns.Tests.Discoverers.TypeTraitsDiscoverer", "Patterns.DesignPatterns.Tests")]
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public sealed class TypeTraitsAttribute : Attribute, ITraitAttribute
    {
        public TraitType Value { get; }

        public TypeTraitsAttribute(TraitType value)
        {
            Value = value;
        }
    }
}
