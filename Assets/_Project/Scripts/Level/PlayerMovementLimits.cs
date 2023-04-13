using UnityEngine;

namespace Game
{
    public class PlayerMovementLimits
    {
        private readonly Camera _camera;
        private readonly float _edgeOffset;
        private float _leftLimit;
        private float _rightLimit;

        public PlayerMovementLimits(Camera camera, float edgeOffset)
        {
            _camera = camera;
            _edgeOffset = edgeOffset;
        }

        public void Activate()
        {
            var distance = -_camera.transform.localPosition.z;

            var leftBorder = _camera.ViewportToWorldPoint(new Vector3(0 + _edgeOffset, 0.5f, distance));
            var rightBorder = _camera.ViewportToWorldPoint(new Vector3(1 - _edgeOffset, 0.5f, distance));

            _leftLimit = leftBorder.x;
            _rightLimit = rightBorder.x;
        }

        public Vector3 Apply(Vector3 nextPosition)
        {
            nextPosition.x = Mathf.Clamp(nextPosition.x, _leftLimit, _rightLimit);

            return nextPosition;
        }
    }
}