using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JokJaBre.Core.Objects
{
    public class ApiException : Exception
    {
        public int ReturnCode { get; set; }
        public ApiException(string message, int returnCode) : base(message)
        {
            ReturnCode = returnCode;
        }
        public ApiException(string message, Exception inner, int returnCode) : base(message, inner)
        {
            ReturnCode = returnCode;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
