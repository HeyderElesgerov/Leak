using System;
using System.Collections.Generic;
using System.Text;

namespace Leak.Domain.Core.ErrorConst
{
    public class ErrorMessageGenerator
    {
        public static string Generate(string fieldName, string message)
        {
            return $"{fieldName}, {message}";
        }
    }
}
