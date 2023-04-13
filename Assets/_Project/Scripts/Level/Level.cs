using SDW.Input;
using UnityEngine;

namespace Game
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Ball _ball;
        [SerializeField] private PlayerMovement[] _playerMovements;

        private BallMovementLimits _ballMovementLimits;
        private BallRespawner _ballRespawner;
        private bool _isActive;
        private PlayerMobileInput _playerMobileInput;
        private PlayerMovementLimits _playerMovementLimits;

        public Ball Ball => _ball;

        private void Update()
        {
            if (!_isActive)
            {
                return;
            }

            foreach (var playerMovement in _playerMovements)
            {
                playerMovement.UpdatePosition();
            }

            _ball.UpdatePosition();

            _ballMovementLimits.Update();
        }

        public void Activate()
        {
            _ballMovementLimits.Activate();
            _ballMovementLimits.Limit(_ball);

            _playerMovementLimits.Activate();

            _ballRespawner.Respawn(_ball);

            _isActive = true;
        }

        public void Construct(PlayerMobileInput playerMobileInput,
                              PlayerMovementLimits playerMovementLimits,
                              BallMovementLimits ballMovementLimits,
                              BallRespawner ballRespawner)
        {
            _ballRespawner = ballRespawner;
            _playerMobileInput = playerMobileInput;
            _ballMovementLimits = ballMovementLimits;
            _playerMovementLimits = playerMovementLimits;

            foreach (var playerMovement in _playerMovements)
            {
                playerMovement.Construct(_playerMovementLimits, _playerMobileInput);
            }
        }
    }
}