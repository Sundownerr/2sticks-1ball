using UnityEngine;

namespace Game
{
    public class LevelFactory
    {
        private readonly Level _prefab;

        public LevelFactory(Level prefab)
        {
            _prefab = prefab;
        }

        public Level CreateLevel()
        {
            var level = Object.Instantiate(_prefab);
            return level;
        }
    }
}