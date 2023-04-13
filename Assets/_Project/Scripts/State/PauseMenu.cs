using UnityEngine;

namespace Game
{
    public class PauseMenu : IState
    {
        private readonly PauseMenuUI _pauseMenuUI;
        private readonly Highscore _highscore;
        private readonly Score _score;
        private readonly PlayerData _playerData;
        private readonly StateMachine _stateMachine;

        public PauseMenu(StateMachine stateMachine, PauseMenuUI pauseMenuUI, Highscore highscore, Score score, PlayerData playerData)
        {
            _stateMachine = stateMachine;
            _pauseMenuUI = pauseMenuUI;
            _highscore = highscore;
            _score = score;
            _playerData = playerData;
        }

        public void Enter()
        {
            Time.timeScale = 0;

            _pauseMenuUI.Show();
            _pauseMenuUI.ResumeButton.onClick.AddListener(OnResumePressed);
            _pauseMenuUI.ExitButton.onClick.AddListener(OnExitPressed);
            _pauseMenuUI.RestartButton.onClick.AddListener(OnRestartPressed);
        }

        public void Exit()
        {
            Time.timeScale = 1;

            _pauseMenuUI.Hide();
            _pauseMenuUI.ResumeButton.onClick.RemoveListener(OnResumePressed);
            _pauseMenuUI.ExitButton.onClick.RemoveListener(OnExitPressed);
            _pauseMenuUI.RestartButton.onClick.RemoveListener(OnRestartPressed);
        }

        private void OnRestartPressed()
        {
            _highscore.Update();
            _score.Value = 0;
            _playerData.Highscore = _highscore.Value;
            
            _stateMachine.SetState<RestartLevel>();
        }

        private void OnExitPressed()
        {
            _stateMachine.SetState<UnloadLevel>();
        }

        private void OnResumePressed()
        {
            _stateMachine.SetState<Gameplay>();
        }
    }
}