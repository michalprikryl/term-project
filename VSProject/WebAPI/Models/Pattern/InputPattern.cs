namespace WebAPI.Models.Pattern
{
    public class InputPattern
    {
        public string Text { get; set; }
        public string Name { get; set; }
        public string JSON { get; set; }
        public int PatternTypeID { get; set; }

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
