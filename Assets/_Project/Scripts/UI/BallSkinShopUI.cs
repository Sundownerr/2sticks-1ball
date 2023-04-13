using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class BallSkinShopUI : MonoBehaviour
    {
        [SerializeField] private Button _exitButton;
        [SerializeField] private Transform _ballSkinContainer;
        [SerializeField] private BallSkinUI _ballSkinUIPrefab;
        public Button ExitButton => _exitButton;

        public event Action<BallSkin> BallSkinSelected;

        public void CreateBallSkinButtons(IEnumerable<BallSkin> ballSkins)
        {
            foreach (var ballSkin in ballSkins)
            {
                var ballSkinUI = Instantiate(_ballSkinUIPrefab, _ballSkinContainer);
                ballSkinUI.SetID(ballSkin.ID);
                ballSkinUI.Button.onClick.AddListener(() => { BallSkinSelected?.Invoke(ballSkin); });
            }
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