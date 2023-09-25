using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace PrjDevOps.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChuckNorrisController : ControllerBase
    {

        public ChuckNorrisController()
        {

        }

        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [HttpGet(Name = "GetChuckNorrisRandom")]
        public string GetChuckNorrisRandom()
        {
            var url = "https://api.chucknorris.io/jokes/random";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [HttpPost(Name = "GetChuckNorrisPost")]
        public string GetChuckNorrisPost(string Category)
        {
            var url = "https://api.chucknorris.io/jokes/random?category=" + Category;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}