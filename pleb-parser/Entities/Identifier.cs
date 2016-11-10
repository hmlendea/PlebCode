using System;

namespace PlebCode.Parser.Entities
{
    public class Identifier : Atom, IComparable<Identifier>
    {
        public string Name { get; private set; }

        public Identifier(int position, string name)
        {
            PositionOfIdentifier = position;
            Name = name;
        }

        public int CompareTo(Identifier other)
        {
            if (other == null)
                return 1;
            
            return Name.CompareTo(other.Name);
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Name, PositionOfIdentifier);
        }
    }
}
