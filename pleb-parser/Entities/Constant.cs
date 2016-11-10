namespace PlebCode.Parser.Entities
{
    public class Constant : Atom
    {
        public string Name { get; private set; }

        public Constant(int position, string name)
        {
            PositionOfIdentifier = position;
            Name = name;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Name, PositionOfIdentifier);
        }
    }
}
