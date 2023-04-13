using SDW.SaveLoad;

namespace Game
{
    public class LoadSavedData : IState
    {
        private readonly BallSkinChanger _ballSkinChanger;
        private readonly Highscore _highscore;
        private readonly ILoader _loader;
        private readonly PlayerData _playerData;
        private readonly StateMachine _stateMachine;

        public LoadSavedData(StateMachine stateMachine,
                             ILoader loader,
                             PlayerData playerData,
                             BallSkinChanger ballSkinChanger,
                             Highscore highscore)
        {
            _stateMachine = stateMachine;
            _loader = loader;
            _playerData = playerData;
            _ballSkinChanger = ballSkinChanger;
            _highscore = highscore;
        }

        public void Enter()
        {
            _loader.Load();
            _ballSkinChanger.SetCurrentSkin(_playerData.SelectedBallSkinID);
            _highscore.Value = _playerData.Highscore;

            _stateMachine.SetState<Start>();
        }

        public void Exit()
        { }
    }
}