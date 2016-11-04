using System;
using System.IO;
using Arkitektum.NorgesAPI.Tjenester;
using Arkitektum.NorgesAPI.Util;
using FluentAssertions;
using Moq;
using Xunit;

namespace Arkitektum.NorgesAPI.Tests.Tjenester
{
    public class FylkeTjenesteTest
    {
        private string FylkeJson()
        {
            return File.ReadAllText($"{AppDomain.CurrentDomain.BaseDirectory}\\Tjenester\\fylker.json");
        }

        [Fact]
        public void FinnFylkeMedNummer()
        {
            var mock = new Mock<IDownloadManager>();
            mock.Setup(m => m.Download(It.IsAny<string>())).Returns(FylkeJson);
            var fylkeTjeneste = new FylkeTjeneste(mock.Object);
            var fylke = fylkeTjeneste.FinnFylkeMedNummer("08");
            fylke.Navn.Should().Be("Telemark");
            fylke.Nummer.Should().Be("08");
        }

        [Fact]
        public void ReturnerNullVedException()
        {
            var mock = new Mock<IDownloadManager>();
            mock.Setup(m => m.Download(It.IsAny<string>())).Throws(new ArgumentException());
            var fylkeTjeneste = new FylkeTjeneste(mock.Object);
            var fylke = fylkeTjeneste.FinnFylkeMedNummer("08");
            fylke.Should().BeNull();
        }

        [Fact]
        public void ReturnerNullVedUkjentNummer()
        {
            var mock = new Mock<IDownloadManager>();
            mock.Setup(m => m.Download(It.IsAny<string>())).Returns(FylkeJson);
            var fylkeTjeneste = new FylkeTjeneste(mock.Object);
            var fylke = fylkeTjeneste.FinnFylkeMedNummer("99");
            fylke.Should().BeNull();
        }
    }
}