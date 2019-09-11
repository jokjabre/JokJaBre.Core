using System;
using System.Collections.Generic;
using System.Text;

namespace JokJaBre.Core.API.Attributes
{
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public sealed class MapAsCollectionAttribute : Attribute
    {
        public Type FirstType { get; private set; }
        public Type SecondType { get; private set; }
        public bool ModelToResponse { get; private set; }

        public MapAsCollectionAttribute(Type firstType, Type secondType, bool modelToResponse)
        {
            FirstType = firstType;
            SecondType = secondType;
            ModelToResponse = ModelToResponse;
        }
    }
}
