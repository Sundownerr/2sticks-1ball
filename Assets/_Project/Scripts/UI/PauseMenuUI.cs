using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class PauseMenuUI : MonoBehaviour
    {
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _exitButton;

        public Button ResumeButton => _resumeButton;
        public Button ExitButton => _exitButton;

        public Button RestartButton => _restartButton;

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