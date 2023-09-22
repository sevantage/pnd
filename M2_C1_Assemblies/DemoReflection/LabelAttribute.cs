using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoReflection
{
    class LabelAttribute : Attribute
    {
        public LabelAttribute(string label)
        {
            this.Label = label;
        }

        public string Label { get; private set; }
    }
}
