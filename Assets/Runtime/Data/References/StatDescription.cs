public class StatDescription : Description
{
    public int Value { get; }

    public StatDescription(string id, int value) : base(id)
    {
        Value = value;
    }
}
