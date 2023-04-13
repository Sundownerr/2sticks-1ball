using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class BallSkinUI : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _id;

        public Button Button => _button;

        public void SetID(string id)
        {
            _id.text = id;
        }
    }
}