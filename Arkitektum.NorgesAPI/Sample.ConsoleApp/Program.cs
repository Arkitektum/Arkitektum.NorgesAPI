using System;
using Arkitektum.NorgesAPI.Tjenester;

namespace Sample.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Oppslag av kommune:");
            IKommuneTjeneste kommuneTjeneste = KommuneTjeneste.GetKommuneTjeneste();
            Console.WriteLine("Nummer:\t0822");
            Console.WriteLine($"Navn:\t{kommuneTjeneste.FinnKommuneMedNummer("0822").Navn}");

            Console.WriteLine();

            Console.WriteLine("Oppslag av fylke:");
            IFylkeTjeneste fylkeTjeneste = FylkeTjeneste.GetFylkeTjeneste();
            Console.WriteLine("Nummer:\t08");
            Console.WriteLine($"Navn:\t{fylkeTjeneste.FinnFylkeMedNummer("08").Navn}");

        }
    }
}