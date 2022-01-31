using Asteroids.SpaceEntity;
using Asteroids.Configs;

namespace Extensions.Asteroid
{
    public static class AsteroidExtensions
    {
        public static float ToSize(this AsteroidState state, AsteroidConfig config)
        {
            switch (state)
            {
                case AsteroidState.Big:
                    return config.BigAsteroidSize;
                case AsteroidState.Medium:
                    return config.MediumAsteroidSize;
                case AsteroidState.Little:
                    return config.LittleAsteroidSize;
                default:
                    return config.BigAsteroidSize;
            }
        }
    }
}