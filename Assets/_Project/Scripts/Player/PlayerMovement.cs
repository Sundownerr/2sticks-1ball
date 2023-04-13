using SDW.Input;
using UnityEngine;

namespace Game
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 1f;
        private PlayerMobileInput _mobileInput;
        private PlayerMovementLimits _playerMovementLimits;
       
        public Vector3 Velocity { get; private set; }

        public void UpdatePosition()
        {
            if (!_mobileInput.IsPressed)
            {
                return;
            }

            var direction = Vector3.right * _mobileInput.PointerDelta.x;
            var nextPosition = transform.position + direction * (Time.deltaTime * _speed);
            nextPosition = _playerMovementLimits.Apply(nextPosition);

            Velocity = (nextPosition - transform.position) / Time.deltaTime;
            transform.position = nextPosition;
        }

        public void Construct(PlayerMovementLimits playerMovementLimits, PlayerMobileInput mobileInput)
        {
            _mobileInput = mobileInput;
            _playerMovementLimits = playerMovementLimits;
        }
    }
}