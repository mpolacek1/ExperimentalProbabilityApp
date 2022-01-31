namespace ExperimentalProbability.Calculations.Models
{
    public class TypeSettings
    {
        public TypeSettings(int poolSize, object pool)
        {
            PoolSize = poolSize;
            Pool = pool;
        }

        public int PoolSize { get; private set; }

        public object Pool { get; private set; }
    }
}
