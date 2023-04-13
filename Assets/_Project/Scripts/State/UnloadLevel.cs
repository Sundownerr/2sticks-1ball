using UnityEngine;

namespace Game
{
    public class UnloadLevel : IState
    {
        private readonly LevelInstance _levelInstance;
        private readonly StateMachine _stateMachine;

        public UnloadLevel(StateMachine stateMachine, LevelInstance levelInstance)
        {
            _stateMachine = stateMachine;
            _levelInstance = levelInstance;
        }

        public void Enter()
        {
            Object.Destroy(_levelInstance.Value.gameObject);
            _stateMachine.SetState<MainMenu>();
        }

        public void Exit()
        {
           
        }
    }
}