public class SeedModel
{
    private ulong _seed;

    public SeedModel(ulong seed)
    {
        _seed = seed;
    }

    public ulong IncrementSeed() => _seed++;
}
