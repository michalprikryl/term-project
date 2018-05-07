using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Models.DataAPI;
using WebAPI.Models.Graphs;

namespace WebAPI.Parsers
{
    public interface IDataParser
    {
        Graph ParseData(string data);
    }
}
