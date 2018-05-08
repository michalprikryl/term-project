namespace WebAPI.Models.DataAPI
{
    public class InputData
    {
        public string Name { get; set; }

        public string Data { get; set; }

        public string DataFormat { get; set; }
    }

    public class InputDataID : InputData
    {
        public int GraphID { get; set; }
    }
}
