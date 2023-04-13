namespace Game
{
    public class BallSkinShop : IState
    {
        private readonly BallSkinChanger _ballSkinChanger;
        private readonly BallSkinShopUI _ballSkinShopUI;
        private readonly PlayerData _playerData;
        private readonly StateMachine _stateMachine;

        public BallSkinShop(StateMachine stateMachine,
                            BallSkinShopUI ballSkinShopUI,
                            BallSkinChanger ballSkinChanger,
                            PlayerData playerData)
        {
            _stateMachine = stateMachine;
            _ballSkinShopUI = ballSkinShopUI;
            _ballSkinChanger = ballSkinChanger;
            _playerData = playerData;
        }

        public void Enter()
        {
            _ballSkinShopUI.Show();

            _ballSkinShopUI.BallSkinSelected += OnBallSkinSelected;
            _ballSkinShopUI.ExitButton.onClick.AddListener(OnExitPressed);
        }

        public void Exit()
        {
            _ballSkinShopUI.Hide();

            _ballSkinShopUI.BallSkinSelected -= OnBallSkinSelected;
            _ballSkinShopUI.ExitButton.onClick.RemoveListener(OnExitPressed);
        }

        private void OnExitPressed()
        {
            _stateMachine.SetState<MainMenu>();
        }

        private void OnBallSkinSelected(BallSkin skin)
        {
            _ballSkinChanger.SetCurrentSkin(skin.ID);
            _playerData.SelectedBallSkinID = skin.ID;
        }
    }
}