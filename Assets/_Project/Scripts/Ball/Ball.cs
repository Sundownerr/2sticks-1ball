using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Transform _skinContainer;
        private float _currentSpeed;
        private Vector3 _defaultPosition;
        private Vector3 _moveDirection;
        private float _speedBoost;
        public GameObject Skin => _skinContainer.GetChild(0).gameObject;

        private void Start()
        {
            _defaultPosition = transform.position;
        }

        private void OnCollisionEnter(Collision collision)
        {
            var normal = collision.contacts[0].normal;
            normal.z = 0;
            _moveDirection = Vector3.Reflect(_moveDirection, normal);

            if (collision.transform.TryGetComponent<PlayerMovement>(out var playerMovement))
            {
                UpdateSpeedBoost(playerMovement);
            }

            Collided?.Invoke(collision);
        }

        public event Action<Collision> Collided;

        public void UpdatePosition()
        {
            _currentSpeed = _speed * _speedBoost;
            _speedBoost = Mathf.MoveTowards(_speedBoost, 1, Time.deltaTime);
            transform.position += _moveDirection * (_currentSpeed * Time.deltaTime);
        }

        private void UpdateSpeedBoost(PlayerMovement playerMovement)
        {
            var velocityMagnitude = playerMovement.Velocity.magnitude / 2f;
            var boost = Mathf.Clamp(velocityMagnitude, 1, 3);

            if (boost > _speedBoost)
            {
                _speedBoost = boost;
            }
        }

        public void ResetPosition()
        {
            _speedBoost = 1;
            transform.position = _defaultPosition;
            _moveDirection = Vector3.zero;
        }

        public void SetRandomMoveDirection()
        {
            var randomDirection = Random.insideUnitSphere;
            randomDirection.z = 0;

            _moveDirection = randomDirection.normalized;
        }
    }
}