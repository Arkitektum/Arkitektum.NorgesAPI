using System.Net;
using System.Text;

namespace Arkitektum.NorgesAPI.Util
{
    internal class DownloadManager : IDownloadManager
    {
        public string Download(string url)
        {
            var c = new WebClient {Encoding = Encoding.UTF8};
            return c.DownloadString(url);
        }
    }
}