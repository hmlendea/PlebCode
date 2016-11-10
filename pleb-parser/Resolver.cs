using System.Collections.Generic;
using System.Text.RegularExpressions;

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
        public List<Identifier> Identifiers { get; private set; }
        public List<Constant> Constants { get; private set; }

        public Resolver(List<string> atoms, Dictionary<string, int> converter)
        {
            this.atoms = atoms;
            this.converter = converter;
        }

        public void BuildFIPandST()
        {
            FIP = new List<Atom>();
            Identifiers = new List<Identifier>();
            Constants = new List<Constant>();

            foreach (string atomName in atoms)
            {
                if (converter.ContainsKey(atomName))
                {
                    Atom atom = new Atom(converter[atomName]);

                    FIP.Add(atom);
                }
                else
                {
                    // TODO: Maybe have an enum (AtomType or something?)
                    bool isIdentifier = false;
                    bool isConstant = false;

                    foreach (Identifier identifier in Identifiers)
                        if (identifier.Name == atomName)
                        {
                            isIdentifier = true;

                            if (identifier.Name.Length > 250)
                                throw new InvalidSyntaxException("Max identif. len 250");

                            FIP.Add(identifier);
                            break;
                        }

                    if (!isIdentifier)
                    {
                        foreach (Constant constant in Constants)
                            if (constant.Name == atomName)
                            {
                                isConstant = true;
                                FIP.Add(constant);
                                break;
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
            List<Identifier> symbolsTableIdentifiers = Identifiers;
            List<Constant> symbolsTableConstants = Constants;

            int index;

            symbolsTableIdentifiers.Sort((identifier1, identifier2) =>
                identifier1.Name.CompareTo(identifier2.Name));

            symbolsTableConstants.Sort((constant1, constant2) =>
                constant1.Name.CompareTo(constant2.Name));

            index = 0;
            foreach (Atom identifier in symbolsTableIdentifiers)
            {
                identifier.PositionOfIdentifier = index;
                index += 1;
            }

            index = 0;
            foreach (Atom constant in symbolsTableConstants)
            {
                constant.PositionOfIdentifier = index;
                index += 1;
            }
        }
    }
}
