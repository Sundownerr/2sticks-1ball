using SDW.SaveLoad;

namespace Game
{
    public class PlayerData : IJsonSaveData
    {
        private readonly string _defaultSkinID;
        private const string CurrentBallSkinKey = "CurrentBallSkin";
        private const string HighscoreKey = "Highscore";

        public int Highscore { get; set; }
        public string SelectedBallSkinID { get; set; }

        public PlayerData(string defaultSkinID)
        {
            _defaultSkinID = defaultSkinID;
        }

        public void SaveTo(IJsonSerializationContainer container)
        {
            container.Add(CurrentBallSkinKey, SelectedBallSkinID);
            container.Add(HighscoreKey, Highscore);
        }

        public void LoadFrom(IJsonSerializationContainer container)
        {
            SelectedBallSkinID = container.Get<string>(CurrentBallSkinKey);
            Highscore = container.Get<int>(HighscoreKey);
        }

        public void OnDefault()
        {
            SelectedBallSkinID = _defaultSkinID;
        }
    }
}