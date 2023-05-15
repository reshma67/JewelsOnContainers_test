namespace WebMvc.Infrastructure
{
    public interface IHttpClient
    {
        Task<String> GetStringAsync(String uri, string AuthorizationToken=null, string authorizationMethod = "Berarer");
    }
}
