namespace WebAPI
{
    public static class Extension
    {
        public static string DeleteParentNodes(this string xml)
        {
            return xml.Replace("<mxCell id=\"0\"/>", "").Replace("<mxCell id=\"1\" parent=\"0\"/>", "");
        }
    }
}
