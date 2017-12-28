using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Parsers
{
    public class Parser
    {
        public DataFormatEnum Type { get; private set; }

        public Parser(DataFormatEnum type)
        {
            Type = type;
        }

        public List<Node> ParseData(string data)
        {
            IDataParser parser;
            switch (Type)
            {
                //case DataFormatEnum.JSON:
                //    parser = new DataParserJSON();
                //    break;
                //case DataFormatEnum.XMI:
                //    parser = new DataParserXMI();
                //    break;
                case DataFormatEnum.XML:
                    parser = new DataParserXML();
                    break;
                default:
                    parser = new DataParserXML();
                    break;
            }

            return parser.ParseData(data);
        }
    }
}
