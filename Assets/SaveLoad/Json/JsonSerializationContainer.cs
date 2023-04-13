using System.Collections.Generic;

namespace SDW.SaveLoad
{
    public class JsonSerializationContainer : IJsonSerializationContainer
    {
        private readonly ISerializer<string> _serializer;
        private Dictionary<string, string> _jsonDictionaryContainer = new();

        public JsonSerializationContainer(ISerializer<string> serializer)
        {
            _serializer = serializer;
        }

        public void Clear()
        {
            _jsonDictionaryContainer.Clear();
        }

        public void Add<T>(string key, T value)
        {
            var serializedValue = _serializer.Serialize(value);

            if (_jsonDictionaryContainer.ContainsKey(key))
            {
                _jsonDictionaryContainer[key] = serializedValue;
                return;
            }

            _jsonDictionaryContainer.Add(key, serializedValue);
        }

        public T Get<T>(string key)
        {
            if (_jsonDictionaryContainer.TryGetValue(key, out var value))
            {
                return _serializer.Deserialize<T>(value);
            }

            return default;
        }

        public string Serialized()
        {
            return _serializer.Serialize(_jsonDictionaryContainer);
        }

        public void FillFrom(string data)
        {
            _jsonDictionaryContainer = _serializer.Deserialize<Dictionary<string, string>>(data);
        }
    }
}