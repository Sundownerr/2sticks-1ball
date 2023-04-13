using UnityEngine;

namespace SDW.SaveLoad
{
    public class SaveTrigger : MonoBehaviour
    {
        private ISaver _saver;

        private void OnApplicationFocus(bool hasFocus)
        {
#if !UNITY_EDITOR
            if (!hasFocus)
            {
                _saver.Save();
            }
#endif
        }

        private void OnApplicationPause(bool pauseStatus)
        {
#if !UNITY_EDITOR
              if (pauseStatus)
            {
                _saver.Save();
            }
#endif
        }

        private void OnApplicationQuit()
        {
            _saver?.Save();
        }

        public void Construct(ISaver saver)
        {
            _saver = saver;
        }
    }
}