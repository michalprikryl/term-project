namespace GLibrary.Models.DataAPI
{
    public class GraphInputData
    {
        public string Name { get; set; }

        public string Data { get; set; }

        public string DataFormat { get; set; }
    }

    public class GraphInputDataID : GraphInputData
    {
        public int GraphID { get; set; }
    }
}
