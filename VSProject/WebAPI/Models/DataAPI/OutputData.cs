namespace WebAPI.Models.DataAPI
{
    public class OutputData
    {
        public string Result { get; set; }

        public OutputData(string result)
        {
            Result = result;
        }
    }

    public class CheckData
    {
        public bool Proper { get; set; }
        public string Message { get; set; }
    }
}
