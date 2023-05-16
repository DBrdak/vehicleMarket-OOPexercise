using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Attributes
{
    public class TranslatedNameAttribute : Attribute
    {
        public string Name { get; }

        public TranslatedNameAttribute(string name)
        {
            Name = name;
        }

        public string Translate() => Name;
        
    }
}
