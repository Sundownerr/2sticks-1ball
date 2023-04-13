using System.Collections.Generic;
using UnityEngine;

namespace SDW.SaveLoad
{
    public class JsonPrefsSaver : ISaver
    {
        private readonly IEnumerable<IJsonSaveWrapper> _saves;
        private readonly IJsonSerializationContainer _serializationContainer;

        public JsonPrefsSaver(IJsonSerializationContainer serializationContainer, IEnumerable<IJsonSaveWrapper> saves)
        {
            _serializationContainer = serializationContainer;
            _saves = saves;
        }

        public void Save()
        {
            foreach (var save in _saves)
            {
                _serializationContainer.Clear();

                var json = save.Serialize(_serializationContainer);

                PlayerPrefs.SetString(save.Key, json);
#if UNITY_EDITOR
                Debug.Log($"[Save] {save.Key}: {json}");
#endif
            }
        }
    }
}