using UnityEngine;

namespace Game
{
    public class Gameplay : IState
    {
        private readonly BallRespawner _ballRespawner;
        private readonly GameplayUI _gameplayUI;
        private readonly Highscore _highscore;
        private readonly LevelInstance _levelInstance;
        private readonly PlayerData _playerData;
        private readonly Score _score;
        private readonly StateMachine _stateMachine;

        public Gameplay(StateMachine stateMachine,
                        GameplayUI gameplayUI,
                        LevelInstance levelInstance,
                        Score score,
                        Highscore highscore,
                        BallRespawner ballRespawner,
                        PlayerData playerData)
        {
            _stateMachine = stateMachine;
            _gameplayUI = gameplayUI;
            _levelInstance = levelInstance;
            _score = score;
            _highscore = highscore;
            _ballRespawner = ballRespawner;
            _playerData = playerData;
        }

        public void Enter()
        {
            SetScore(_score.Value);
            _gameplayUI.Show();

            _gameplayUI.PauseButton.onClick.AddListener(OnPausePressed);
            _levelInstance.Value.Ball.Collided += OnBallCollided;
            _ballRespawner.BallRespawned += OnBallRespawned;
        }

        public void Exit()
        {
            _gameplayUI.Hide();

            _gameplayUI.PauseButton.onClick.RemoveListener(OnPausePressed);
            _levelInstance.Value.Ball.Collided -= OnBallCollided;
            _ballRespawner.BallRespawned -= OnBallRespawned;
        }

        private void OnBallRespawned()
        {
            SetScore(0);
        }

        private void OnBallCollided(Collision collision)
        {
            if (!collision.transform.TryGetComponent<PlayerMovement>(out var _))
            {
                return;
            }

            SetScore(_score.Value + 1);
        }

        private void SetScore(int value)
        {
            _score.Value = value;
            _gameplayUI.SetScore(_score.Value);
            _highscore.Update();
            _playerData.Highscore = _highscore.Value;
        }

        private void OnPausePressed()
        {
            _stateMachine.SetState<PauseMenu>();
        }
    }
}