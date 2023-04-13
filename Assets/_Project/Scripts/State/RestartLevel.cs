using UnityEngine;

namespace Game
{
    public class RestartLevel : IState
    {
        private readonly LevelInstance _levelInstance;

        private readonly StateMachine _stateMachine;

        public RestartLevel(StateMachine stateMachine, LevelInstance levelInstance)
        {
            _stateMachine = stateMachine;
            _levelInstance = levelInstance;
        }

        public void Enter()
        {
            Object.Destroy(_levelInstance.Value.gameObject);
            _stateMachine.SetState<LoadLevel>();
        }

        public void Exit()
        { }
    }
}