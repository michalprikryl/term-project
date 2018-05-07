using Database;
using WebAPI.Parsers;
using WebAPI.Services;

namespace WebAPI.Models.Validators
{
    public class PatternValidator : IValidator
    {
        private TermProjectContext _db;
        private DataFormatEnum _format;

        public PatternValidator(TermProjectContext db, DataFormatEnum format)
        {
            _db = db;
            _format = format;
        }

        public bool Validate()
        {
            var patternGraphs = PatternToGraph.GetPatterns(_db, _format);

            return true;
        }
    }
}
