using Data.References.Common;
using TinyJSON;

namespace Data.References.Stat
{
    public class StatDescription : Description
    {
        public int Value { get; }

        public StatDescription(string id, Variant variant) : base(id)
        {
            Value = variant;
        }
    }
}
