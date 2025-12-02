using System;
using System.Collections.Generic;
using System.Text;
using TinyJSON;

namespace Data.Model.Random
{
    public class SeedModelCollection
    {
        public Dictionary<string, SeedModel> Seeds { get; }

        public SeedModelCollection()
        {
            Seeds = new();
        }

        public SeedModelCollection(Variant variant) : this()
        {
            var seedsData = (ProxyObject)variant;

            foreach (var pair in seedsData)
            {
                ulong value = pair.Value;
                Seeds[pair.Key] = new SeedModel(value);
            }
        }

        public SeedModel this[string key]
        {
            get
            {
                if (!Seeds.ContainsKey(key))
                {
                    var model = InitializeSeed();
                    Seeds[key] = model;
                }
                return Seeds[key];
            }
        }

        public string Serialize()
        {
            var builder = new StringBuilder("{");
            foreach (var pair in Seeds)
            {
                builder = builder.Append($"\"{pair.Key}\":{pair.Value.Serialize()},");
            }
            builder[^1] = '}';

            return builder.ToString();
        }

        private SeedModel InitializeSeed() => new SeedModel((ulong)DateTime.UtcNow.Ticks);
    }
}
