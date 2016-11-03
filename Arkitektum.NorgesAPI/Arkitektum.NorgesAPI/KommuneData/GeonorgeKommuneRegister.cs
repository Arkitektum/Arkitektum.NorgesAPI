using Arkitektum.NorgesAPI.Util;
using Newtonsoft.Json.Linq;

namespace Arkitektum.NorgesAPI.KommuneData
{
    internal class GeonorgeKommuneRegister
    {
        private readonly IDownloadManager _downloadManager;

        private static readonly string KommunenummerOppslagUrl = "https://register.geonorge.no/api/subregister/sosi-kodelister/kartverket/kommunenummer/kartverket/{0}";

        public GeonorgeKommuneRegister(IDownloadManager downloadManager)
        {
            _downloadManager = downloadManager;
        }

        public Kommune FinnKommuneMedNummer(string kommuneNummer)
        {
            string responseData = _downloadManager.Download(KommunenummerOppslagUrl);

            JObject kommuneJson = JObject.Parse(responseData);
            string navn = (string)kommuneJson["label"];

            return new Kommune { Navn = navn, Nummer = kommuneNummer};
        }

    }
}
