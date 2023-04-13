using System.Collections.Generic;
using UnityEngine;

namespace SDW.SaveLoad
{
    public class JsonPrefsLoader : ILoader
    {
        private readonly IEnumerable<IJsonSaveWrapper> _saves;
        private readonly IJsonSerializationContainer _serializationContainer;

        public JsonPrefsLoader(IJsonSerializationContainer serializationContainer, IEnumerable<IJsonSaveWrapper> saves)
        {
            _serializationContainer = serializationContainer;
            _saves = saves;
        }

        public void Load()
        {
            foreach (var save in _saves)
            {
                _serializationContainer.Clear();
                
                var existingJson = PlayerPrefs.GetString(save.Key);

                if (string.IsNullOrEmpty(existingJson))
                {
                    save.SetDefault();

#if UNITY_EDITOR
                    Debug.LogWarning($"[Not found] {save.Key} : {save.Serialize(_serializationContainer)}");
#endif
                }
                else
                {
                    save.Deserialize(existingJson, _serializationContainer);
#if UNITY_EDITOR
                    Debug.Log($"[Load] {save.Key}: {existingJson}");
#endif
                }
            }
        }
    }
}