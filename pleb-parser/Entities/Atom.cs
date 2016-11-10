namespace PlebCode.Parser.Entities
{
    public class Atom
    {
        public int Code { get; set; }
        public int PositionOfIdentifier { get; set; }

        public Atom()
        {
        }

        public Atom(int code)
            : this(code, -1)
        {
        }

        public Atom(int code, int positionOfIdentifier)
        {
            Code = code;
            PositionOfIdentifier = positionOfIdentifier;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Code, PositionOfIdentifier);
        }
    }
}
