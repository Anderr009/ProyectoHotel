using Hotel.web.Interface;

namespace Hotel.web.Service
{
    public class BaseHttpClient : IBaseRequestHttpClient
    {
        private static HttpClient _context = new HttpClient();

        public BaseHttpClient( )
        {
        }
        public string Get(string url)
        {
            return (_context.GetAsync(url).Result).Content.ReadAsStringAsync().Result; 
        }

        public string Post(string url, StringContent data)
        {
            return (_context.PostAsync(url,data).Result).Content.ReadAsStringAsync().Result;
        }

        public string Put(string url, StringContent data)
        {
            return (_context.PutAsync(url, data).Result).Content.ReadAsStringAsync().Result;
        }
    }
}
