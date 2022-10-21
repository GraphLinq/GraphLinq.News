    using NodeBlock.Engine;
using NodeBlock.Engine.Attributes;
using System;

namespace NodeBlock.Plugin.News.Nodes.CryptoPanic
{
    [NodeDefinition("GetCryptoPanicPostsNode", "Get CryptoPanic Posts", NodeTypeEnum.Function, "News.CryptoPanic")]
    [NodeGraphDescription("Get CryptoPanic Posts")]

    public class GetCryptoPanicPostsNode : Node
    {

        public GetCryptoPanicPostsNode(string id, BlockGraph graph)
           : base(id, graph, typeof(GetCryptoPanicPostsNode).Name)
        {
            InParameters.Add("cryptopanicConnection", new NodeParameter(this, "cryptopanicConnection", typeof(CryptoPanicConnectorNode), true));
            //this.InParameters.Add("optionalFilter", new NodeParameter(this, "optionalFilter", typeof(string), false));
            //this.InParameters.Add("optionalCurrencies", new NodeParameter(this, "optionalCurrencies", typeof(string), false));
            //this.InParameters.Add("optionalRegions", new NodeParameter(this, "optionalRegions", typeof(string), false));
            //this.InParameters.Add("optionalKind", new NodeParameter(this, "optionalKind", typeof(string), false));

            OutParameters.Add("postsData", new NodeParameter(this, "postsData", typeof(string), false));
        }

        public override bool CanBeExecuted => true;

        public override bool CanExecute => true;

        public override bool OnExecution()
        {
            //var apiKey = (this.InParameters["cryptopanicConnection"].GetValue() as CryptoPanicConnectorNode).InParameters["apiKey"].GetValue();
            //Console.WriteLine(apiKey);
            //var optionalFilter = this.InParameters["optionalFilter"].GetValue();
            //var optionalCurrencies = this.InParameters["optionalCurrencies"].GetValue();
            //var optionalRegions = this.InParameters["optionalRegions"].GetValue();
            //var optionalKind = this.InParameters["optionalKind"].GetValue();

            //var response = client.GetAsync("https://cryptopanic.com/api/v1/posts/?public=true&auth_token=" + apiKey).Result;
            //var responseContent = request.Content.ReadAsStringAsync();
            Console.WriteLine("IN EXECUTION");
            CryptoPanicConnectorNode CryptoPanicConnectorNode = InParameters["cryptopanicConnection"].GetValue() as CryptoPanicConnectorNode;

            System.Threading.Tasks.Task<API.PostsResponse> postsRequest = CryptoPanicConnectorNode.API.FetchCryptoPanicPosts(
            //this.InParameters["currency"].GetValue().ToString(),
            //this.InParameters["start"].GetValue(),
            //this.InParameters["end"].GetValue()
            );
            postsRequest.Wait();

            Console.WriteLine("InNideResponse");
            Console.WriteLine(postsRequest.Result);
            Console.WriteLine("InNideResponse");
            //var fff = JsonConvert.DeserializeObject<Root>(response.Content.ReadAsStringAsync().Result);
            //Console.WriteLine(myDeserializedClass.ToString());
            //Console.WriteLine(fff.ToString());




            //var response = client.GetAsync("https://avascan.info/api/v1/burned-fees").Result;
            //var avascanBurnedFeesResponse = JsonConvert.DeserializeObject<AvascanBurnedFeesHttpResult>(response.Content.ReadAsStringAsync().Result);
            //
            OutParameters["postsData"].SetValue("nodatayet");

            return true;
        }
    }
}
