namespace Game
{
    public class MainMenu : IState
    {
        private readonly Highscore _highscore;
        private readonly MainMenuUI _mainMenuUI;
        private readonly PlayerData _playerData;
        private readonly Score _score;
        private readonly StateMachine _stateMachine;

        public MainMenu(StateMachine stateMachine,
                        MainMenuUI mainMenuUI,
                        Highscore highscore,
                        Score score,
                        PlayerData playerData)
        {
            _stateMachine = stateMachine;
            _mainMenuUI = mainMenuUI;
            _highscore = highscore;
            _score = score;
            _playerData = playerData;
        }

        public void Enter()
        {
            _highscore.Update();
            _score.Value = 0;
            _playerData.Highscore = _highscore.Value;

            _mainMenuUI.Show();
            _mainMenuUI.SetHighScore(_highscore.Value);

            _mainMenuUI.PlayButton.onClick.AddListener(OnPlayPressed);
            _mainMenuUI.SkinShopButton.onClick.AddListener(OnSkinShopPressed);
        }

        public void Exit()
        {
            _mainMenuUI.Hide();

            _mainMenuUI.PlayButton.onClick.RemoveListener(OnPlayPressed);
            _mainMenuUI.SkinShopButton.onClick.RemoveListener(OnSkinShopPressed);
        }

        private void OnSkinShopPressed()
        {
            _stateMachine.SetState<BallSkinShop>();
        }

        private void OnPlayPressed()
        {
            _stateMachine.SetState<LoadLevel>();
        }
    }
}