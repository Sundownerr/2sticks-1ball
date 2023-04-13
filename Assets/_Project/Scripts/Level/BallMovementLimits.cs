using UnityEngine;

namespace Game
{
    public class BallMovementLimits
    {
        private readonly Camera _camera;
        private readonly BallRespawner _ballRespawner;
        private readonly float _edgeOffset;
        private Ball _ball;
        private float _bottomLimit;
        private float _topLimit;

        public BallMovementLimits(Camera camera, BallRespawner ballRespawner, float edgeOffset)
        {
            _camera = camera;
            _ballRespawner = ballRespawner;
            _edgeOffset = edgeOffset;
        }

        public void Activate()
        {
            var distance = -_camera.transform.localPosition.z;

            var topBorder = _camera.ViewportToWorldPoint(new Vector3(0.5f, 1 - _edgeOffset, distance));
            var bottomBorder = _camera.ViewportToWorldPoint(new Vector3(0.5f, 0 + _edgeOffset, distance));

            _topLimit = topBorder.y;
            _bottomLimit = bottomBorder.y;
        }

        public void Limit(Ball ball)
        {
            _ball = ball;
        }

        public void Update()
        {
            if (_ball.transform.position.y > _topLimit || _ball.transform.position.y < _bottomLimit)
            {
                _ballRespawner.Respawn(_ball);
            }
        }
    }
}