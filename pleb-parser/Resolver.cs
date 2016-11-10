using System.Collections.Generic;
using System.Text.RegularExpressions;

using PlebCode.Infrastructure.Collections;
using PlebCode.Infrastructure.Exceptions;
using PlebCode.Parser.Entities;

namespace PlebCode.Parser
{
    public class Resolver
    {
        const string ConstantPattern = "(:?(^[A-Z]+$)|(:?(^[0-9]+$)|(^[0-9]+\\.[0-9]+$)))";
        const string IdentifierPattern = "^[a-z]+$";

        readonly List<string> atoms;
        readonly Dictionary<string, int> converter;

        public List<Atom> FIP { get; private set; }
        public BinarySearchTree<Identifier> Identifiers { get; private set; }
        public BinarySearchTree<Constant> Constants { get; private set; }

        public Resolver(List<string> atoms, Dictionary<string, int> converter)
        {
            this.atoms = atoms;
            this.converter = converter;
        }

        public void BuildFIPandST()
        {
            FIP = new List<Atom>();
            Identifiers = new BinarySearchTree<Identifier>();
            Constants = new BinarySearchTree<Constant>();

            foreach (string atomName in atoms)
            {
                if (converter.ContainsKey(atomName))
                {
                    Atom atom = new Atom(converter[atomName]);

                    FIP.Add(atom);
                }
                else
                {
                    BinarySearchTreeIterator<Identifier> identifierIterator;
                    BinarySearchTreeIterator<Constant> constantIterator;
                    
                    // TODO: Maybe have an enum (AtomType or something?)
                    bool isIdentifier = false;
                    bool isConstant = false;

                    identifierIterator = Identifiers.CreateIterator();
                    while (identifierIterator.Valid)
                    {
                        Identifier identifier = identifierIterator.CurrentElement;

                        if (identifier.Name == atomName)
                        {
                            isIdentifier = true;

                            if (identifier.Name.Length > 250)
                                throw new InvalidSyntaxException("Max identif. len 250");

                            FIP.Add(identifier);
                            break;
                        }

                        identifierIterator.Next();
                    }

                    if (!isIdentifier)
                    {
                        identifierIterator = Identifiers.CreateIterator();
                        while (identifierIterator.Valid)
                        {
                            constantIterator = Constants.CreateIterator();
                            while (constantIterator.Valid)
                            {
                                Constant constant = constantIterator.CurrentElement;

                                if (constant.Name == atomName)
                                {
                                    isConstant = true;
                                    FIP.Add(constant);
                                    break;
                                }

                                constantIterator.Next();
                            }

                            identifierIterator.Next();
                        }

                        if (!isConstant)
                            AddConstantOrIdentifier(atomName);
                    }
                }
            }

            SortSymbolTable();
        }

        void AddConstantOrIdentifier(string atomName)
        {
            if (Regex.IsMatch(atomName, IdentifierPattern))
            {
                Identifier identifier = new Identifier(-1, atomName);

                FIP.Add(identifier);
                Identifiers.Add(identifier);
            }
            else if (Regex.IsMatch(atomName, ConstantPattern))
            {
                Constant constant = new Constant(-1, atomName);

                FIP.Add(constant);
                Constants.Add(constant);
            }
        }

        void SortSymbolTable()
        {
            BinarySearchTreeIterator<Identifier> identifierIterator = Identifiers.CreateIterator();
            BinarySearchTreeIterator<Constant> constantIterator = Constants.CreateIterator();

            int index;

            index = 0;
            while (identifierIterator.Valid)
            {
                Identifier identifier = identifierIterator.CurrentElement;

                identifier.PositionOfIdentifier = index;
                index += 1;

                identifierIterator.Next();
            }

            index = 0;
            while (constantIterator.Valid)
            {
                Constant constant = constantIterator.CurrentElement;

                constant.PositionOfIdentifier = index;
                index += 1;

                constantIterator.Next();
            }
        }
    }
}
