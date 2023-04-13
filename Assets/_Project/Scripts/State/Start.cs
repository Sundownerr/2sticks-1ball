namespace Game
{
    public class Start : IState
    {
        private readonly BallSkinShopUI _ballSkinShopUI;
        private readonly BallSkin[] _ballSkins;
        private readonly GameplayUI _gameplayUI;
        private readonly MainMenuUI _mainMenuUI;
        private readonly PauseMenuUI _pauseMenuUI;
        private readonly StateMachine _stateMachine;

        public Start(StateMachine stateMachine,
                     PauseMenuUI pauseMenuUI,
                     GameplayUI gameplayUI,
                     MainMenuUI mainMenuUI,
                     BallSkinShopUI ballSkinShopUI,
                     BallSkin[] ballSkins)
        {
            _stateMachine = stateMachine;
            _pauseMenuUI = pauseMenuUI;
            _gameplayUI = gameplayUI;
            _mainMenuUI = mainMenuUI;
            _ballSkinShopUI = ballSkinShopUI;
            _ballSkins = ballSkins;
        }

        public void Enter()
        {
            _pauseMenuUI.Hide();
            _gameplayUI.Hide();
            _mainMenuUI.Hide();
            _ballSkinShopUI.Hide();
            
            _ballSkinShopUI.CreateBallSkinButtons(_ballSkins);

            _stateMachine.SetState<MainMenu>();
        }

        public void Exit()
        { }
    }
}