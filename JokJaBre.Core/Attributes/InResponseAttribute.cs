using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace JokJaBre.Core.Attributes
{
    [System.AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public sealed class ShownAttribute : Attribute
    {
        // See the attribute guidelines at 
        //  http://go.microsoft.com/fwlink/?LinkId=85236
        readonly string positionalString;
        public Dto ShownIn { get; }
        // This is a positional argument
        public ShownAttribute(Dto dto = Dto.Both, [CallerMemberName]string positionalString = null)
        {
            this.positionalString = positionalString;
            ShownIn = dto;
            // TODO: Implement code here

        }

        public string PositionalString
        {
            get { return positionalString; }
        }

        // This is a named argument
        //public int NamedInt { get; set; }
    }
}
