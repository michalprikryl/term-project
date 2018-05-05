namespace WebAPI.Parsers
{
    public enum DataFormatEnum
    {
        XML, XMI, JSON, Unsupported
    }

    public static class DataFormat
    {
        public static DataFormatEnum GetDataFormatByString(string dataformat)
        {
            DataFormatEnum format;
            switch (dataformat)
            {
                case "xml":
                    format = DataFormatEnum.XML;
                    break;
                case "json":
                    format = DataFormatEnum.JSON;
                    break;
                case "xmi":
                    format = DataFormatEnum.XMI;
                    break;
                default:
                    format = DataFormatEnum.Unsupported;
                    break;
            }

            return format;
        }
    }
}
