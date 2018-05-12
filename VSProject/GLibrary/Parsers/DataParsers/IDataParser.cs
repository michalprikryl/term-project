using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GLibrary.Models;
using GLibrary.Models.DataAPI;
using GLibrary.Models.Graphs;

namespace GLibrary.Parsers
{
    public interface IDataParser
    {
        Graph ParseData(string data);
    }
}
