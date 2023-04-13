using System;
using System.Collections.Generic;

namespace Game
{
    public class StateMachine
    {
        private readonly Dictionary<Type, IState> _states = new();
        private IState _currentState;

        public void AddState<T>(T state) where T : IState
        {
            var type = typeof(T);

            if (_states.ContainsKey(type))
            {
                return;
            }

            _states.Add(type, state);
        }

        public void SetState<T>() where T : IState
        {
            _currentState?.Exit();
            _currentState = _states[typeof(T)];
            _currentState.Enter();
        }
    }
}