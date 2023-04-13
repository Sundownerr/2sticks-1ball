using System;

namespace Game
{
    [Serializable]
    public class GameConfig
    {
        public float PlayerMovementEdgeLimit;
        public float BallRespawnEdgeLimit;
        public float BallRespawnDelay;
        public float BorderEdgeOffset;
    }
}