using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _highScore;
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _skinShopButton;

        public Button PlayButton => _playButton;
        public Button SkinShopButton => _skinShopButton;

        public void SetHighScore(int highScore)
        {
            _highScore.text = highScore.ToString();
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