using System;

namespace Stan
{
    interface Stan
    {
        void alert();
    }

    class Powiadomienia
    {
        private Stan aktualnyStan;

        public Powiadomienia()
        {
            aktualnyStan = new Dzwonek();
            return;
        }

        public void ustawStan(Stan stan)
        {
            aktualnyStan = stan;
        }

        public void alert()
        {
            aktualnyStan.alert();
        }
    }

    class Dzwonek : Stan
    {
        public void alert()
        {
            Console.WriteLine("dzwonek...");
        }
    }

    class Wibracja : Stan
    {
        public void alert()
        {
            Console.WriteLine("wibracja...");
        }
    }

    class Wyciszenie : Stan
    {
        public void alert()
        {
            Console.WriteLine("wyciszenie...");
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            Powiadomienia powiadomienia = new Powiadomienia();
            powiadomienia.ustawStan(new Wibracja());
            powiadomienia.alert();
            powiadomienia.ustawStan(new Dzwonek());
            powiadomienia.alert();
            powiadomienia.ustawStan(new Wyciszenie());
            powiadomienia.alert();
            powiadomienia.alert();
            powiadomienia.ustawStan(new Wibracja());
            powiadomienia.alert();
        }
    }
}