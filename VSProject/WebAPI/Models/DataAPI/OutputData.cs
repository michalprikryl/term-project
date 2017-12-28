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
}
