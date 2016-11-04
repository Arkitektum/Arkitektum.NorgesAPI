using System;
using Arkitektum.NorgesAPI.Tjenester;

namespace Sample.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IKommuneTjeneste kommuneTjeneste = KommuneTjeneste.GetKommuneTjeneste();
            Console.WriteLine("0822: " + kommuneTjeneste.FinnKommuneMedNummer("0822").Navn);
        }
    }
}