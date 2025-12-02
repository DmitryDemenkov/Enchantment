using System;

namespace Data.Model.Item
{
    public class StatModel
    {
        public event Action<int> Changed;

        public string Id { get; }
        public int Value { get; private set; }

        public StatModel(string id, int value)
        {
            Id = id;
            Value = value;
        }

        public void Add(int value)
        {
            Value += value;
            Changed?.Invoke(Value);
        }

        public string Serialize()
        {
            return $"\"{Id}\":{Value}";
        }
    }
}
