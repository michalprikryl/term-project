using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Models.DataAPI;

namespace WebAPI.Parsers
{
    public interface IDataParser
    {
        List<Node> ParseData(string data);
    }
}
