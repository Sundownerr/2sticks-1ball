using SDW.Input;

namespace Game
{
    public class ConstructLevel : IState
    {
        private readonly BallMovementLimits _ballMovementLimits;
        private readonly BallRespawner _ballRespawner;
        private readonly BallSkinChanger _ballSkinChanger;
        private readonly BorderFactory _borderFactory;
        private readonly LevelInstance _levelInstance;
        private readonly PlayerMobileInput _playerMobileInput;
        private readonly PlayerMovementLimits _playerMovementLimits;
        private readonly StateMachine _stateMachine;

        public ConstructLevel(StateMachine stateMachine,
                              LevelInstance levelInstance,
                              PlayerMobileInput playerMobileInput,
                              PlayerMovementLimits playerMovementLimits,
                              BallMovementLimits ballMovementLimits,
                              BallRespawner ballRespawner,
                              BorderFactory borderFactory,
                              BallSkinChanger ballSkinChanger)
        {
            _stateMachine = stateMachine;
            _levelInstance = levelInstance;
            _playerMobileInput = playerMobileInput;
            _playerMovementLimits = playerMovementLimits;
            _ballMovementLimits = ballMovementLimits;
            _ballRespawner = ballRespawner;
            _borderFactory = borderFactory;
            _ballSkinChanger = ballSkinChanger;
        }

        public void Enter()
        {
            var level = _levelInstance.Value;

            level.Construct(_playerMobileInput, _playerMovementLimits, _ballMovementLimits, _ballRespawner);
            _borderFactory.CreateBorders(level.transform);

            _ballSkinChanger.ChangeToCurrentSkin(level.Ball);

            level.Activate();

            _stateMachine.SetState<Gameplay>();
        }

        public void Exit()
        { }
    }
}