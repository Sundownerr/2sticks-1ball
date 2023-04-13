namespace Game
{
    public class LoadLevel : IState
    {
        private readonly LevelFactory _levelFactory;
        private readonly LevelInstance _levelInstance;

        private readonly StateMachine _stateMachine;

        public LoadLevel(StateMachine stateMachine, LevelFactory levelFactory, LevelInstance levelInstance)
        {
            _stateMachine = stateMachine;
            _levelFactory = levelFactory;
            _levelInstance = levelInstance;
        }

        public void Enter()
        {
            var level = _levelFactory.CreateLevel();
            _levelInstance.Value = level;

            _stateMachine.SetState<ConstructLevel>();
        }

        public void Exit()
        { }
    }
}