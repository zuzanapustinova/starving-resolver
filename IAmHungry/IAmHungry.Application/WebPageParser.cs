using HtmlAgilityPack;
using IAmHungry.Application.Abstractions;
using System.Text;
using System.Xml.Linq;

namespace IAmHungry.Application
{
    public class WebPageParser : IWebPageParser
    {
        public WebPageParser()
        {

        }

        public HtmlDocument LoadPage(string url)
        {
            var web = new HtmlWeb
            {
                OverrideEncoding = Encoding.UTF8
            };
            var doc = web.Load(url);
            return doc;
        }

        public List<string> GetNodesInnerText(HtmlDocument doc, string node)
        {
            var nodes = new List<string>();
            try
            {
                var htmlNodes = doc.DocumentNode.SelectNodes(node);
                if (htmlNodes == null)
                {
                    var message = $"GetNodesInnerText Node {node} was not found";
                    nodes.Add(message);
                }
                else
                {
                    nodes.AddRange(htmlNodes.Select(htmlNode => htmlNode.InnerText));
                }  
            }
            catch 
            {
                throw new Exception($"Node {node} was not found");
            }
            
            return nodes;
        }

        public List<HtmlNode> FindNodes(HtmlDocument doc, string node)
        {
            return doc.DocumentNode.SelectNodes(node).ToList();
        }

        public string GetSingleNodeInnerText(HtmlDocument doc, string node)
        {
            var innerText = "";
            var htmlNode = doc.DocumentNode.SelectSingleNode(node);
            innerText = htmlNode != null ? htmlNode.InnerText : node;
            return innerText;
        }
    }
}
