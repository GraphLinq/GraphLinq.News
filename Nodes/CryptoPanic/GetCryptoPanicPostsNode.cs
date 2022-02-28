using Newtonsoft.Json;
using NodeBlock.Engine;
using NodeBlock.Engine.Attributes;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace NodeBlock.Plugin.News.Nodes.CryptoPanic
{
    [NodeDefinition("GetCryptoPanicPostsNode", "Get CryptoPanic Posts", NodeTypeEnum.Function, "News.CryptoPanic")]
    [NodeGraphDescription("Get CryptoPanic Posts")]

    public class GetCryptoPanicPostsNode : Node
    {
        public class GetCryptoPanicPostsHttpResult
        {
            public string count { get; set; }
            public string next { get; set; }
            public string previous { get; set; }
            public string results { get; set; }
            public class Results
            {
                public string kind { get; set; }
                public string domain { get; set; }
                public string votes { get; set; }
                public string source { get; set; }
                public string title { get; set; }
                public string published_at { get; set; }
                public string slug { get; set; }
                public int id { get; set; }
                public string url { get; set; }
                public string created_at { get; set; }

            }
        }

        private readonly HttpClient client = new HttpClient();

        public GetCryptoPanicPostsNode(string id, BlockGraph graph)
           : base(id, graph, typeof(GetCryptoPanicPostsNode).Name)
        {
            this.InParameters.Add("cryptopanicConnection", new NodeParameter(this, "cryptopanicConnection", typeof(CryptoPanicConnectorNode), true));
            this.InParameters.Add("optionalFilter", new NodeParameter(this, "optionalFilter", typeof(string), false));
            this.InParameters.Add("optionalCurrencies", new NodeParameter(this, "optionalCurrencies", typeof(string), false));
            this.InParameters.Add("optionalRegions", new NodeParameter(this, "optionalRegions", typeof(string), false));
            this.InParameters.Add("optionalKind", new NodeParameter(this, "optionalKind", typeof(string), false));

            this.OutParameters.Add("postsData", new NodeParameter(this, "postsData", typeof(string), false));
        }

        public override bool CanBeExecuted => true;

        public override bool CanExecute => true;

        public override bool OnExecution()
        {
            var apiKey = (this.InParameters["cryptopanicConnection"].GetValue() as CryptoPanicConnectorNode).InParameters["apiKey"].GetValue();
            Console.WriteLine(apiKey);
            var optionalFilter = this.InParameters["optionalFilter"].GetValue();
            var optionalCurrencies = this.InParameters["optionalCurrencies"].GetValue();
            var optionalRegions = this.InParameters["optionalRegions"].GetValue();
            var optionalKind = this.InParameters["optionalKind"].GetValue();
            var response = client.GetAsync("https://cryptopanic.com/api/v1/posts/?public=true&auth_token=" + apiKey).Result;
            var postDataResponse = JsonConvert.DeserializeObject<GetCryptoPanicPostsHttpResult>(response.Content.ReadAsStringAsync().Result);
            Console.WriteLine(postDataResponse);
            this.OutParameters["postsData"].SetValue(postDataResponse.results);

            return true;
        }
    }
}
