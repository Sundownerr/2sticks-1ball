using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "SO/Ball skin", fileName = "BallSkin", order = 0)]
    public class BallSkin : ScriptableObject
    {
        public string ID;
        public GameObject Prefab;
    }
}