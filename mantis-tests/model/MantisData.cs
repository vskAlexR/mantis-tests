using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class MantisData : IComparable<MantisData>, IEquatable<MantisData>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Id { get; set; }


        public bool Equals(MantisData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (object.ReferenceEquals(this, other))
            {
                return true;
            }
            return this.ToString() == other.ToString();
        }
        public int CompareTo(MantisData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return this.ToString().CompareTo(other.ToString());
        }
        public override string ToString()
        {
            return this.Name + this.Description;
        }
    }
}