using UnityEngine;

namespace Game
{
    public class BorderFactory
    {
        private readonly Camera _camera;
        private readonly float _edgeOffset;
        private readonly GameObject _prefab;

        public BorderFactory(GameObject prefab, Camera camera, float edgeOffset)
        {
            _prefab = prefab;
            _camera = camera;
            _edgeOffset = edgeOffset;
        }

        public void CreateBorders(Transform parent)
        {
            var distance = -_camera.transform.localPosition.z;

            var leftBorder = Object.Instantiate(_prefab, parent);
            var rightBorder = Object.Instantiate(_prefab, parent);

            leftBorder.transform.position = _camera.ViewportToWorldPoint(new Vector3(0 + _edgeOffset, 0.5f, distance));
            rightBorder.transform.position = _camera.ViewportToWorldPoint(new Vector3(1 - _edgeOffset, 0.5f, distance));
        }
    }
}