using UnityEngine;

namespace Game
{
    public class BallSkinChanger
    {
        private readonly BallSkin[] _ballSkins;

        private string _currentSkinID;

        public BallSkinChanger(BallSkin[] ballSkins)
        {
            _ballSkins = ballSkins;
        }

        public void SetCurrentSkin(string skinId)
        {
            _currentSkinID = skinId;
        }

        public void ChangeToCurrentSkin(Ball ball)
        {
            var skin = Skin(_currentSkinID);

            var skinParent = ball.Skin.transform.parent;
            Object.Destroy(ball.Skin);

            Object.Instantiate(skin.Prefab, skinParent);
          
        }

        private BallSkin Skin(string skinId)
        {
            foreach (var ballSkin in _ballSkins)
            {
                if (ballSkin.ID == skinId)
                {
                    return ballSkin;
                }
            }

            return null;
        }
    }
}