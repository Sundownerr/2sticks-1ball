namespace SDW.SaveLoad
{
    public interface ISaveWrapper<TSaveKey, TSerializedData, TSerializationContainer>
    {
        TSaveKey Key { get; }
        void SetDefault();
        TSerializedData Serialize(TSerializationContainer serializationContainer);
        void Deserialize(TSerializedData serializedData, TSerializationContainer serializationContainer);
    }
}