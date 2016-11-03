using System;
using System.IO;
using Arkitektum.NorgesAPI.KommuneData;
using Arkitektum.NorgesAPI.Util;
using FluentAssertions;
using Moq;
using Xunit;

namespace Arkitektum.NorgesAPI.Tests.KommuneData
{
    public class KommuneTjenesteTest
    {
        private string KommuneJson()
        {
            return File.ReadAllText($"{AppDomain.CurrentDomain.BaseDirectory}\\KommuneData\\kommune.json");
        }

        [Fact]
        public void FinnKommuneMedNummer()
        {
            var mock = new Mock<IDownloadManager>();
            mock.Setup(m => m.Download(It.IsAny<string>())).Returns(KommuneJson());
            var kommuneTjeneste = new KommuneTjeneste(mock.Object);
            Kommune kommune = kommuneTjeneste.FinnKommuneMedNummer("0822");
            kommune.Navn.Should().Be("Sauherad");
            kommune.Nummer.Should().Be("0822");
        }

        [Fact]
        public void ReturnerNullVedException()
        {
            var mock = new Mock<IDownloadManager>();
            mock.Setup(m => m.Download(It.IsAny<string>())).Throws(new ArgumentException());
            var kommuneTjeneste = new KommuneTjeneste(mock.Object);
            Kommune kommune = kommuneTjeneste.FinnKommuneMedNummer("0822");
            kommune.Should().BeNull();
        }
    }
}