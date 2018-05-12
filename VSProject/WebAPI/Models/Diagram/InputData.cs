using GLibrary.Models.DataAPI;

namespace WebAPI.Models.DataAPI
{
    public class InputData
    {
        public string Name { get; set; }

        public string Data { get; set; }

        public string DataFormat { get; set; }

        public GraphInputData GetLibraryModel()
        {
            return new GraphInputData { Data = Data, DataFormat = DataFormat, Name = Name };
        }
    }

    public class InputDataID : InputData
    {
        public int GraphID { get; set; }

        public new GraphInputDataID GetLibraryModel()
        {
            return new GraphInputDataID { Data = Data, DataFormat = DataFormat, Name = Name, GraphID = GraphID };
        }
    }
}
