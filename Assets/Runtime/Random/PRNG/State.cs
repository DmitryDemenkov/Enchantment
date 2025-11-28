public class State
{
    private ulong _s0, _s1, _s2, _s3;

    public State(ulong seed)
    {
        _s0 = _s1 = _s2 = _s3 = 0;
        ulong x = seed;
        _s0 = SplitMix64(ref x);
        _s1 = SplitMix64(ref x);
        _s2 = SplitMix64(ref x);
        _s3 = SplitMix64(ref x);
    }

    private ulong SplitMix64(ref ulong x)
    {
        ulong z = (x += 0x9E3779B97F4A7C15UL);
        z = (z ^ (z >> 30)) * 0xBF58476D1CE4E5B9UL;
        z = (z ^ (z >> 27)) * 0x94D049BB133111EBUL;
        return z ^ (z >> 31);
    }

    private static ulong RotL(ulong x, int k) => (x << k) | (x >> (64 - k));

    public ulong GetRandomValue()
    {
        ulong result = RotL(_s0 + _s3, 23) + _s0;

        ulong t = _s1 << 17;

        _s2 ^= _s0;
        _s3 ^= _s1;
        _s1 ^= _s2;
        _s0 ^= _s3;

        _s2 ^= t;
        _s3 = RotL(_s3, 45);

        return result;
    }
}
