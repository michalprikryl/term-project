using WebAPI.Models.Graphs;

namespace WebAPI.Parsers
{
    public class Parser
    {
        private bool _check;

        public DataFormatEnum Type { get; private set; }

        public Parser(DataFormatEnum type, bool check = true)
        {
            Type = type;
            _check = check;
        }

        public Graph ParseData(string data)
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
                    parser = new DataParserXML(_check);
                    break;
                default:
                    parser = new DataParserXML(_check);
                    break;
            }

            return parser.ParseData(data);
        }
    }
}
