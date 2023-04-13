using System.Collections;
using UnityEngine;

namespace Game
{
    public class BallHighlighter : MonoBehaviour
    {
        private static readonly int HighlightDirection = Shader.PropertyToID("_HighlightDirection");
        private static readonly int HighlightPosition = Shader.PropertyToID("_HighlightPosition");
        private static readonly int BlendAmount = Shader.PropertyToID("_BlendAmount");
        [SerializeField] private Ball _ball;
        private MeshRenderer _ballRenderer;
        private IEnumerator _blendRoutine;

        private void Start()
        {
            _ball.Collided += OnBallCollided;
        }

        private void OnDestroy()
        {
            _ball.Collided -= OnBallCollided;
        }

        private void OnBallCollided(Collision obj)
        {
            _ballRenderer = _ball.Skin.GetComponent<MeshRenderer>();
            _ballRenderer.material.SetVector(HighlightDirection, -obj.contacts[0].normal);
            _ballRenderer.material.SetVector(HighlightPosition, obj.contacts[0].point);
            _ballRenderer.material.SetFloat(BlendAmount, 1);

            if (_blendRoutine != null)
            {
                StopCoroutine(_blendRoutine);
            }

            _blendRoutine = FadeBlend();
            StartCoroutine(FadeBlend());
        }

        private IEnumerator FadeBlend()
        {
            var time = 0f;
            var fadeTime = 0.8f;

            while (time < fadeTime)
            {
                time += Time.deltaTime;
                _ballRenderer.material.SetFloat(BlendAmount, 1 - time / fadeTime);
                yield return null;
            }
        }
    }
}