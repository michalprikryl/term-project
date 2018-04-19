using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.Pattern
{
    public class InputPattern
    {
        public string Text { get; set; }
        public string Name { get; set; }
        public string JSON { get; set; }

        /// <summary>
        /// validuje objekt, pokud vrati true je validni, pokud false, tak neni
        /// </summary>
        /// <returns></returns>
        public bool Validate()
        {
            return !(string.IsNullOrEmpty(Text) || string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(JSON));
        }
    }
}
