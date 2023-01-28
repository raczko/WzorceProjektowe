using System;
using System.Text;


interface ILetters
{
    public string ShowAlfa();
}

interface INumbers
{
    public string ShowNum();
}

class AlphabetFactory
{

    private SystemFactory systemFactory;

    public ILetters letters;
    public INumbers numbers;


    public AlphabetFactory(SystemFactory systemFactory)
    {
        this.systemFactory = systemFactory;
    }

    public void Generate()
    {
        numbers = systemFactory.CreateNum();
        letters = systemFactory.CreateAlfa();
    }

}


abstract class SystemFactory
{
    public abstract ILetters CreateAlfa();
    public abstract INumbers CreateNum();
}


class LacinkaFactory : SystemFactory
{
    public override ILetters CreateAlfa()
    {
        return new LacinkaLetters();
    }

    public override INumbers CreateNum()
    {
        return new LacinkaNumbers();
    }
}

class CyrylicaFactory : SystemFactory
{
    public override ILetters CreateAlfa()
    {
        return new CyrylicaLetters();
    }

    public override INumbers CreateNum()
    {
        return new CyrylicaNumbers();
    }
}

class GrekaFactory : SystemFactory
{
    public override ILetters CreateAlfa()
    {
        return new GrekaLetters();
    }

    public override INumbers CreateNum()
    {
        return new GrekaNumbers();
    }
}

class LacinkaLetters : ILetters
{
    string letters;

    public LacinkaLetters()
    {
        letters = "abcde";
    }

    public string ShowAlfa()
    {
        return letters;
    }
}

class LacinkaNumbers : INumbers
{
    string numbers;

    public LacinkaNumbers()
    {
        numbers = "I II III";
    }

    public string ShowNum()
    {
        return numbers;
    }
}

class GrekaLetters : ILetters
{
    string letters;

    public GrekaLetters()
    {
        letters = "αβγδε";
    }

    public string ShowAlfa()
    {
        return letters;
    }
}
class GrekaNumbers : INumbers
{
    string numbers;

    public GrekaNumbers()
    {
        numbers = "αʹ βʹ γʹ";
    }

    public string ShowNum()
    {
        return numbers;
    }
}


class CyrylicaNumbers : INumbers
{
    string numbers;

    public CyrylicaNumbers()
    {
        numbers = "1 2 3";
    }

    public string ShowNum()
    {
        return numbers;
    }
}

class CyrylicaLetters : ILetters
{
    string letters;

    public CyrylicaLetters()
    {
        letters = "абвгд";
    }

    public string ShowAlfa()
    {
        return letters;
    }
}

public class Application
{
    public static void Main(String[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        //lacina
        AlphabetFactory alphabet_lacinka = new AlphabetFactory(new LacinkaFactory());


        //Cyrlica
        AlphabetFactory alphabet_cyrylica = new AlphabetFactory(new CyrylicaFactory());


        //greka
        AlphabetFactory alphabet_greka = new AlphabetFactory(new GrekaFactory());



        alphabet_lacinka.Generate();

        Console.WriteLine(alphabet_lacinka.letters.ShowAlfa() + " " + alphabet_lacinka.numbers.ShowNum());

        alphabet_cyrylica.Generate();

        Console.WriteLine(alphabet_cyrylica.letters.ShowAlfa() + " " + alphabet_cyrylica.numbers.ShowNum());


        alphabet_greka.Generate();

        Console.WriteLine(alphabet_greka.letters.ShowAlfa() + " " + alphabet_greka.numbers.ShowNum());
    }
}


