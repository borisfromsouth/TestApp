using System.Net.Http;
using System.Threading.Tasks;

namespace TestApp.Models
{
    public class MyAsyncMethods
    {
        public static Task<long?> GetPageLength()
        {
            HttpClient client = new HttpClient();
            var httpTask = client.GetAsync("http://apress.com");   // выполняется асинхронно
            return httpTask.ContinueWith((Task<HttpResponseMessage> antecedent) =>   // ContinueWith обрабатывает результат из GetAsync
            {
                return antecedent.Result.Content.Headers.ContentLength;
            });
        }
    }
}
