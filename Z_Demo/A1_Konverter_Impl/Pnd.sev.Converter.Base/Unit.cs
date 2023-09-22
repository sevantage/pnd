using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sevantage.Pnd.Converter.Base;

namespace Pnd.sev.Converter.Base
{
    public class Unit : sevantage.Pnd.Converter.Base.Unit
    {
        protected readonly string name;

        public Unit(string name)
        {
            this.name = name;
        }

        public override string Name => name;

        public override int CompareTo(sevantage.Pnd.Converter.Base.Unit other)
        {
            if (other == null)
                return 1;
            var result = Name.CompareTo(other.Name);
            if (result != 0)
                return result;
            // Falls gleich benannt, Typnamen als Fallback nutzen
            return GetType().FullName.CompareTo(other.GetType().FullName);
        }

        public override bool Equals(sevantage.Pnd.Converter.Base.Unit other)
        {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Unit);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
