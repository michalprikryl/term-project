using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using WebAPI.Models;
using WebAPI.Models.DataAPI;

namespace WebAPI.Parsers
{
    public class DataParser
    {
        public DataFormatEnum Type { get; private set; }

        public DataParser(DataFormatEnum type)
        {
            Type = type;
        }

        public List<Node> ParseData(string data)
        {
            List<Node> graph = new List<Node>();

            switch (Type)
            {
                case DataFormatEnum.JSON:

                    break;
                case DataFormatEnum.XMI:

                    break;
                case DataFormatEnum.XML:
                    InputXML cell = XMLParser(data);
                    break;
            }


            return graph;
        }

        private InputXML XMLParser(string data)
        {
            InputXML xml = new InputXML();
            using (MemoryStream stream = new MemoryStream(Encoding.ASCII.GetBytes(data)))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(MxGraphModel));
                xml.Graph = serializer.Deserialize(stream) as MxGraphModel;
            }

            return xml;
        }
    }
}
