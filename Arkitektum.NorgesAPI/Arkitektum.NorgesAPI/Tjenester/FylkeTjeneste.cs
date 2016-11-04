using System;
using System.Diagnostics;
using Arkitektum.NorgesAPI.Util;
using Newtonsoft.Json.Linq;

namespace Arkitektum.NorgesAPI.Tjenester
{
    public class FylkeTjeneste : IFylkeTjeneste
    {
        private readonly IDownloadManager _downloadManger;
        private static readonly string FylkesnummerOppslagUrl = "https://register.geonorge.no/api/subregister/sosi-kodelister/kartverket/fylkesnummer/";

        internal FylkeTjeneste(IDownloadManager downloadManger)
        {
            _downloadManger = downloadManger;
        }

        public static IFylkeTjeneste GetFylkeTjeneste()
        {
            return new FylkeTjeneste(new DownloadManager());
        }

        public Fylke FinnFylkeMedNummer(string fylkesnummer)
        {
            try
            {
                string respons = _downloadManger.Download(FylkesnummerOppslagUrl);

                JObject json = JObject.Parse(respons);
                var fylkerArray = json["containeditems"];

                foreach (var fylkeElement in fylkerArray)
                {
                    JToken codeValueToken = fylkeElement["codevalue"];
                    string elementFylkesnummer = codeValueToken?.ToString();
                    if (!string.IsNullOrWhiteSpace(elementFylkesnummer) && string.Equals(elementFylkesnummer, fylkesnummer))
                    {
                        JToken labelToken = fylkeElement["label"];
                        string navn = labelToken?.ToString();
                        return new Fylke {Navn = navn, Nummer = fylkesnummer};
                    }
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine("Exception ved oppslag av fylke med nummer: " + fylkesnummer + ". Melding: " + e.Message);
            }
            return null;
        }
    }
}
