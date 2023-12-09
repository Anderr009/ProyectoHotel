namespace Hotel.Web.Interface
{
    public interface IBaseRequestHttpClient
    {
        string Get(string url);
        string Post(string url, StringContent data);
        string Put(string url, StringContent data);
    }
}
