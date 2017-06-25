using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WSCME.Infrastructure.Validation
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class NameAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {

            return false;
        }
    }
}
