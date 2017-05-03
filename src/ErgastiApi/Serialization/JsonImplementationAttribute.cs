using System;
using System.Collections.Generic;

namespace ErgastApi.Serialization
{
    // TODO: Actually implement this in InterfaceJsonConverter - use to specify specific implementation instead of guessing

    public class JsonImplementationAttribute : Attribute
    {
        public Type ImplementationType { get; set; }

        public JsonImplementationAttribute(Type implementationType)
        {
            ImplementationType = implementationType;
        }
    }
}
