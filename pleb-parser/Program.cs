using System;
using System.Collections.Generic;
using System.IO;

using PlebCode.Infrastructure.Collections;
using PlebCode.Infrastructure.Exceptions;
using PlebCode.Parser.Entities;

namespace PlebCode.Parser
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // TODO: Proper handling
            if (args.Length == 0)
                return;

            // TODO: Check path validity
            string fileName = args[0];

            List<string> atoms = GetAtoms(fileName);
            Dictionary<string, int> converter = GetConverter();

            Resolver resolver = new Resolver(atoms, converter);

            try
            {
                resolver.BuildFIPandST();

                PrintIdentifiers(resolver.Identifiers);
                PrintConstants(resolver.Constants);

                Console.WriteLine("===> The FIP:");
                foreach (Atom atom in resolver.FIP)
                    Console.WriteLine(atom.Code + " - " + atom.PositionOfIdentifier);
            }
            catch (InvalidSyntaxException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static List<string> GetAtoms(string filePath)
        {
            List<string> atoms = new List<string>();
            StreamReader sr = new StreamReader(File.OpenRead(filePath));

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] elements = line.Trim().Split(' ');

                foreach (string element in elements)
                    if (!string.IsNullOrWhiteSpace(element))
                        atoms.Add(element);
            }

            return atoms;
        }

        static Dictionary<string, int> GetConverter()
        {
            Dictionary<string, int> table = new Dictionary<string, int>();
            string tablePath = Path.Combine("Resources", "Table.txt");

            StreamReader sr = new StreamReader(File.OpenRead(tablePath));

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();

                if (string.IsNullOrEmpty(line))
                    continue;

                string[] lineSplit = line.Split(' ');

                string key = lineSplit[1];
                int val = int.Parse(lineSplit[0]);

                table.Add(key, val);
            }

            return table;
        }

        static void PrintIdentifiers(BinarySearchTree<Identifier> identifiers)
        {
            BinarySearchTreeIterator<Identifier> iterator = identifiers.CreateIterator();

            Console.WriteLine("===> The symbols table for identifiers:");

            while (iterator.Valid)
            {
                Console.WriteLine(iterator.CurrentElement);
                iterator.Next();
            }
        }

        static void PrintConstants(BinarySearchTree<Constant> constants)
        {
            BinarySearchTreeIterator<Constant> iterator = constants.CreateIterator();

            Console.WriteLine("===> The symbols table for constants:");

            while (iterator.Valid)
            {
                Console.WriteLine(iterator.CurrentElement);
                iterator.Next();
            }
        }
    }
}
