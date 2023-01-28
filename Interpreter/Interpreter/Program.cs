﻿using System;
using System.Collections.Generic;
namespace Interpreter
{

    public class Program
    {
        public static void Main(string[] args)
        {
            string roman = "MDXLIII";
            string roman2 = "CMXVII";

            Context context = new Context(roman);
            Context context2 = new Context(roman2);

            List<Phrase> tree = new List<Phrase>();
            tree.Add(new PhraseThousands());
            tree.Add(new PhraseHundreds());
            tree.Add(new PhraseTens());
            tree.Add(new PhraseOnes());

            foreach (Phrase exp in tree)
            {
                exp.Interpreter(context);

            }
            Console.WriteLine("{0} = {1}",
                roman, context.Output);

            foreach (Phrase exp in tree)
            {
                exp.Interpreter(context2);

            }

            Console.WriteLine("{0} = {1}", roman2, context2.Output);

        }
    }

    public class Context
    {
        string input;
        int output;
        // Constructor
        public Context(string input)
        {
            this.input = input;
        }
        public string Input
        {
            get { return input; }
            set { input = value; }
        }
        public int Output
        {
            get { return output; }
            set { output = value; }
        }
    }

    public abstract class Phrase
    {
        public void Interpreter(Context context)
        {
            if (context.Input.Length == 0)
                return;
            if (context.Input.StartsWith(Nine()))
            {
                context.Output += (9 * Multiplier());
                context.Input = context.Input.Substring(2);
            }
            else if (context.Input.StartsWith(Four()))
            {
                context.Output += (4 * Multiplier());
                context.Input = context.Input.Substring(2);
            }
            else if (context.Input.StartsWith(Five()))
            {
                context.Output += (5 * Multiplier());
                context.Input = context.Input.Substring(1);
            }
            while (context.Input.StartsWith(One()))
            {
                context.Output += (1 * Multiplier());
                context.Input = context.Input.Substring(1);
            }
        }
        public abstract string One();
        public abstract string Four();
        public abstract string Five();
        public abstract string Nine();
        public abstract int Multiplier();
    }

    public class PhraseThousands : Phrase
    {
        public override string One() { return "M"; }
        public override string Four() { return " "; }
        public override string Five() { return " "; }
        public override string Nine() { return " "; }
        public override int Multiplier() { return 1000; }
    }

    public class PhraseHundreds : Phrase
    {
        public override string One() { return "C"; }
        public override string Four() { return "CD"; }
        public override string Five() { return "D"; }
        public override string Nine() { return "CM"; }
        public override int Multiplier() { return 100; }
    }

    public class PhraseTens : Phrase
    {
        public override string One() { return "X"; }
        public override string Four() { return "XL"; }
        public override string Five() { return "L"; }
        public override string Nine() { return "XC"; }
        public override int Multiplier() { return 10; }
    }

    public class PhraseOnes : Phrase
    {
        public override string One() { return "I"; }
        public override string Four() { return "IV"; }
        public override string Five() { return "V"; }
        public override string Nine() { return "IX"; }
        public override int Multiplier() { return 1; }
    }
}