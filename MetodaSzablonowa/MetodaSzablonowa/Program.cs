using System;

abstract class ZamowienieTemplatka
{
    abstract public void doKoszyk();
    abstract public void doPlatnosc();
    abstract public void doDostawa();

    public void dodanieGratisu()
    {
        Console.WriteLine("Dodano gratis...");
    }

    public void przetwarzajZamowienie(bool czyGratis)
    {
        doKoszyk();
        doPlatnosc();
        if (czyGratis) dodanieGratisu();
        doDostawa();
    }
}


class ZamowienieOnline : ZamowienieTemplatka
{
    override public void doKoszyk()
    {
        Console.WriteLine("Kompletowanie zamówienia...");
        Console.WriteLine("Ustawiono parametry wysyłki...");
    }

    override public void doPlatnosc()
    {
        Console.WriteLine("Płatność...");
    }

    override public void doDostawa()
    {
        Console.WriteLine("Wysyłka...");
    }
}

class ZamowienieStacjonarne : ZamowienieTemplatka
{

    override public void doKoszyk()
    {
        Console.WriteLine("Wybranie produktów...");
    }

    override public void doPlatnosc()
    {
        Console.WriteLine("Płatność w kasie (karta/gotówka)...");
    }

    override public void doDostawa()
    {
        Console.WriteLine("Wydanie produktów (odbiór osobisty)...");
    }
}

class Program
{
    public static void Main(String[] args)
    {
        ZamowienieTemplatka zamowienieOnline = new ZamowienieOnline();
        zamowienieOnline.przetwarzajZamowienie(true);

        Console.WriteLine();

        ZamowienieTemplatka zamowienieStacjonarne = new ZamowienieStacjonarne();
        zamowienieStacjonarne.przetwarzajZamowienie(false);
    }
}