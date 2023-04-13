using System;
using System.Collections;
using UnityEngine;

namespace Game
{
    public class BallRespawner
    {
        public event  Action BallRespawned;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly float _respawnDelay;

        public BallRespawner(ICoroutineRunner coroutineRunner, float respawnDelay)
        {
            _coroutineRunner = coroutineRunner;
            _respawnDelay = respawnDelay;
        }

        public void Respawn(Ball ball)
        {
            _coroutineRunner.StartCoroutine(RespawnAfterDelay(ball, _respawnDelay));
            BallRespawned?.Invoke();
        }

        private IEnumerator RespawnAfterDelay(Ball ball, float respawnDelay)
        {
            ball.ResetPosition();
            
            var time = 0f;

            while (time < respawnDelay)
            {
                time += Time.deltaTime;
                yield return null;
            }

            ball.SetRandomMoveDirection();
        }
    }
}