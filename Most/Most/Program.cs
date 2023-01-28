using System;


public interface ITelewizor
{

    int Kanal { get; set; }
    void Wlacz();
    void Wylacz();
    void ZmienKanal(int kanal);

}



public class TvLg : ITelewizor
{

    public TvLg()
    {
        this.Kanal = 1;
    }

    public int Kanal { get; set; }

    public void Wlacz()
    {
        Console.WriteLine("Telewizor LG - włączam się.");
    }

    public void Wylacz()
    {
        Console.WriteLine("Telewizor LG - wyłączam się.");
    }

    public void ZmienKanal(int kanal)
    {
        this.Kanal = kanal;
        Console.WriteLine($"Telewizor LG - zmieniam kanał: {kanal}");
    }

}



public class TvXiaomi : ITelewizor
{
    public TvXiaomi()
    {
        this.Kanal = 1;
    }

    public int Kanal { get; set; }

    public void Wlacz()
    {
        Console.WriteLine("Telewizor Xiaomi - włączam się.");
    }

    public void Wylacz()
    {
        Console.WriteLine("Telewizor Xiaomi - wyłączam się.");
    }

    public void ZmienKanal(int kanal)
    {
        Kanal = kanal;
        Console.WriteLine($"Telewizor Xiaomi - zmieniam kanał: {kanal}");
    }
}



public abstract class PilotAbstrakcyjny
{

    private ITelewizor tv;

    public PilotAbstrakcyjny(ITelewizor tv)
    {
        this.tv = tv;
    }
    public void Wlacz()
    {
        tv.Wlacz();
    }
    public void Wylacz()
    {
        tv.Wylacz();
    }

    public void ZmienKanal(int kanal)
    {
        tv.ZmienKanal(kanal);
    }

}



public class PilotHarmony : PilotAbstrakcyjny
{

    public PilotHarmony(ITelewizor tv) : base(tv) { }

    public void DoWlacz()
    {
        Console.WriteLine("Pilot Harmony - włącz telewizor...");
        Wlacz();
    }
    public void DoWylacz()
    {
        Console.WriteLine("Pilot Harmony - wyłącz telewizor...");
        Wylacz();
    }
    public void DoZmienKanal(int kanal)
    {
        Console.WriteLine($"Pilot Harmony - zmienia kanał: {kanal} ");
        ZmienKanal(kanal);

    }

}

public class PilotPhilips : PilotAbstrakcyjny
{

    public PilotPhilips(ITelewizor tv) : base(tv) { }

    public void DoWlacz()
    {
        Console.WriteLine("Pilot Philips - włącz telewizor...");
        Wlacz();
    }
    public void DoWylacz()
    {
        Console.WriteLine("Pilot Philips - wyłącz telewizor...");
        Wylacz();
    }
    public void DoZmienKanal(int kanal)
    {
        Console.WriteLine("Pilot Philips - zmienia kanał... ");
        ZmienKanal(kanal);
    }

}

public class PilotLG : PilotAbstrakcyjny
{

    public PilotLG(ITelewizor tv) : base(tv) { }

    public void DoWlacz()
    {
        Console.WriteLine("Pilot LG - - włącz telewizor...");
        Wlacz();
    }
    public void DoWylacz()
    {
        Console.WriteLine("Pilot LG - - wyłącz telewizor...");
        Wylacz();
    }
    public void DoZmienKanal(int kanal)
    {
        Console.WriteLine("Pilot LG - zmienia kanał... ");
        ZmienKanal(kanal);
    }

}



class MainClass
{
    public static void Main(string[] args)
    {

        ITelewizor tv = new TvLg();
        PilotHarmony pilotHarmony = new PilotHarmony(tv);
        PilotLG pilotLG = new PilotLG(tv);

        pilotHarmony.DoWlacz();
        Console.WriteLine("Sprawdź kanał - bieżący kanał: " + tv.Kanal);
        pilotLG.DoZmienKanal(100);
        Console.WriteLine("Sprawdź kanał - bieżący kanał: " + tv.Kanal);
        pilotHarmony.DoWylacz();

    }
}