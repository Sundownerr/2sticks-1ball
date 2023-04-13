using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class GameplayUI : MonoBehaviour
    {
        [SerializeField] private Button _pauseButton;
        [SerializeField] private TMP_Text _score;

        public Button PauseButton => _pauseButton;

        public void SetScore(int score)
        {
            _score.text = score.ToString();
        }
        
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}