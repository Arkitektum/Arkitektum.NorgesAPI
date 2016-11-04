using System;
using System.Diagnostics;
using Arkitektum.NorgesAPI.Util;
using Newtonsoft.Json.Linq;

namespace Arkitektum.NorgesAPI.Tjenester
{
    public class KommuneTjeneste : IKommuneTjeneste
    {
        private readonly IDownloadManager _downloadManager;

        private static readonly string KommunenummerOppslagUrl = "https://register.geonorge.no/api/subregister/sosi-kodelister/kartverket/kommunenummer/kartverket/{0}";

        /// <summary>
        /// External services should depeend on interface not the implementation class
        /// </summary>
        internal KommuneTjeneste(IDownloadManager downloadManager)
        {
            _downloadManager = downloadManager;
        }

        public static IKommuneTjeneste GetKommuneTjeneste()
        {
            return new KommuneTjeneste(new DownloadManager());
        }

        public Kommune FinnKommuneMedNummer(string kommuneNummer)
        {
            try
            {
                string respons = _downloadManager.Download(string.Format(KommunenummerOppslagUrl, kommuneNummer));

                JObject kommuneJson = JObject.Parse(respons);
                string navn = (string) kommuneJson["label"];

                return new Kommune {Navn = navn, Nummer = kommuneNummer};
            }
            catch (Exception e)
            {
                Trace.WriteLine("Exception ved oppslag av kommune med nummer: " + kommuneNummer + ". Melding: " + e.Message);
            }
            return null;
        }
    }
}
