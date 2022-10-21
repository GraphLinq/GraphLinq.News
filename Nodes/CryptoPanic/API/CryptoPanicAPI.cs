using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NodeBlock.Plugin.News.Nodes.CryptoPanic.API
{
    public class CryptoPanicAPI
    {

        public string APIKey { get; }
        private readonly HttpClient client = new HttpClient();
        private readonly string baseUrl = "https://cryptopanic.com/api/v1";

        public CryptoPanicAPI(string apiKey)
        {
            APIKey = apiKey;
            //this.client.DefaultRequestHeaders.Add("x-api-key", this.APIKey);
        }

        public async Task<PostsResponse> FetchCryptoPanicPosts()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            Console.WriteLine("We here in CP API File");
            Console.WriteLine(APIKey);

            HttpResponseMessage request = await client.GetAsync(baseUrl + "/posts?auth_token=" + APIKey);
            string responseContent = await request.Content.ReadAsStringAsync();
            Console.WriteLine(responseContent);
            PostsResponse data = JsonConvert.DeserializeObject<PostsResponse>(responseContent, settings);
            return data;
        }
    }
}
