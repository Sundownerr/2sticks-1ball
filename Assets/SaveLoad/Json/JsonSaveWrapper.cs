namespace SDW.SaveLoad
{
    public class JsonSaveWrapper<T> : IJsonSaveWrapper where T : IJsonSaveData
    {
        private readonly T _data;
      
        public JsonSaveWrapper(string key, T data)
        {
            _data = data;
            Key = key;
        }

        public string Key { get; }

        public void SetDefault()
        {
            _data.OnDefault();
        }

        public string Serialize(IJsonSerializationContainer serializationContainer)
        {
            _data.SaveTo(serializationContainer);
            return serializationContainer.Serialized();
        }

        public void Deserialize(string serializedData, IJsonSerializationContainer serializationContainer)
        {
            serializationContainer.FillFrom(serializedData);
            _data.LoadFrom(serializationContainer);
        }
    }
}