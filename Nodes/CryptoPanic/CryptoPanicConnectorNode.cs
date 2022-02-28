using NodeBlock.Engine;
using NodeBlock.Engine.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

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
            this.InParameters.Add("apiKey", new NodeParameter(this, "apiKey", typeof(string), true));

            this.OutParameters.Add("cryptopanicConnection", new NodeParameter(this, "cryptopanicConnection", typeof(CryptoPanicConnectorNode), true));
        }


        public override bool CanBeExecuted => false;

        public override bool CanExecute => true;

        public override void SetupConnector()
        {
            this.Next();
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
