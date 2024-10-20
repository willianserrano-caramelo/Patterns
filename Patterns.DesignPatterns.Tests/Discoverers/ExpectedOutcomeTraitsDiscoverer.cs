using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Patterns.DesignPatterns.Tests.Discoverers
{
    public class ExpectedOutcomeTraitsDiscoverer : ITraitDiscoverer
    {
        public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
        {
            var traitValue = traitAttribute.GetConstructorArguments().GetEnumerator();
            traitValue.MoveNext();
            var value = traitValue.Current?.ToString();

            if (!string.IsNullOrEmpty(value))
            {
                yield return new KeyValuePair<string, string>("ExpectedOutcome", value);
            }
        }
    }
}
