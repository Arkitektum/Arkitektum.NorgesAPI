﻿using System;
using Arkitektum.NorgesAPI.KommuneData;

namespace Sample.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IKommuneTjeneste kommuneTjeneste = KommuneTjeneste.GetKommuneTjeneste();
            Console.WriteLine("0822: " + kommuneTjeneste.FinnKommuneMedNummer("0822"));
        }
    }
}