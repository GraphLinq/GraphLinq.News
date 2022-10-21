using NodeBlock.Engine;
using NodeBlock.Engine.Attributes;

namespace NodeBlock.Plugin.News.Nodes.CryptoPanic
{
    [NodeDefinition("CryptoPanicConnectorNode", "CryptoPanic Connector", NodeTypeEnum.Connector, "News.CryptoPanic")]
    [NodeSpecialActionAttribute("Go to CryptoPanic API Portal", "open_url", "https://cryptopanic.com/developers/api/")]
    [NodeGraphDescription("Connection to the CryptoPanic API")]
    public class CryptoPanicConnectorNode : Node
    {
        public CryptoPanicConnectorNode(string id, BlockGraph graph)
          : base(id, graph, typeof(CryptoPanicConnectorNode).Name)
        {
            CanBeSerialized = false;

            InParameters.Add("apiKey", new NodeParameter(this, "apiKey", typeof(string), true));

            OutParameters.Add("cryptopanicConnection", new NodeParameter(this, "cryptopanicConnection", typeof(CryptoPanicConnectorNode), true));
        }

        public API.CryptoPanicAPI API { get; set; }

        public override bool CanBeExecuted => false;

        public override bool CanExecute => true;

        public override void SetupConnector()
        {
            API = new API.CryptoPanicAPI(InParameters["apiKey"].GetValue().ToString());

            Next();
        }

        public override object ComputeParameterValue(NodeParameter parameter, object value)
        {
            if (parameter.Name == "cryptopanicConnection")
            {
                return this;
            }

            return base.ComputeParameterValue(parameter, value);
        }
    }
}
