namespace PRNG
{
    public class Random
    {
        private ulong _seed;
        private State _state;

        public Random(ulong seed)
        {
            _seed = seed;
            _state = new State(_seed);
        }

        public double Chance()
            => (_state.GetRandomValue() >> 11) * (1.0 / (1UL << 53));

        public int Range(int min, int max)
        {
            if (min > max) return min;
            if (min == max) return min;

            ulong range = (ulong)(max - min + 1);
            ulong x;
            ulong limit = ulong.MaxValue - ulong.MaxValue % range;

            do
            {
                x = _state.GetRandomValue();
            } while (x >= limit);

            return min + (int)(x % range);
        }
    }
}
