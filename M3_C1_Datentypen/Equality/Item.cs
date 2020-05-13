using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equality
{
    class Item : IEquatable<Item>
    {
        #region Fields
        private readonly int id;
        #endregion

        #region Constructors
        public Item(int id)
        {
            this.id = id;
        }
        #endregion

        #region Properties
        public int Id
        {
            get
            {
                return id;
            }
        }

        public string Name { get; set; }
        #endregion

        #region "Equals & GetHashCode"

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Item);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public bool Equals(Item other)
        {
            if (other == null)
                return false;
            return this.Id == other.Id
                && string.Compare(this.Name, other.Name, true) == 0;
        }

        #endregion
        
        #region Operators

        public static bool operator ==(Item x, Item y)
        {
            if (object.ReferenceEquals(x, y))
                return true;
            if (((object)x) == null
                || ((object)y) == null)
                return false;
            return x.Equals(y);
        }

        public static bool operator !=(Item x, Item y)
        {
            return !(x == y);
        }

        #endregion
    }
}
