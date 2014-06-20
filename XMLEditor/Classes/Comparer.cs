using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLEditor.Classes
{

    class Comparer : IEqualityComparer<string>
    {

        // Products are equal if their names and product numbers are equal.
        public bool Equals(string x, string y)
        {          

            //Check whether the products' properties are equal.
            if (x == y) { return true; } else { return false; }
        }
        public int GetHashCode(string s)
        {
            //Check whether the object is null
            if (Object.ReferenceEquals(s, null)) return 0;

            //Get hash code for the Name field if it is not null.
            int hashProductName = s == null ? 0 : s.GetHashCode();

            //Get hash code for the Code field.
            int hashstringCode = s.GetHashCode();

            //Calculate the hash code for the product.
            return hashProductName ^ hashstringCode;
        }

    }
}
