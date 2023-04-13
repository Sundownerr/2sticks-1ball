namespace SDW.SaveLoad
{
    public interface ISerializationContainer<TKey, TSerialized>
    {
        void Add<T>(TKey key, T value);
        T Get<T>(TKey key);
        void Clear();
        TSerialized Serialized();
        void FillFrom(TSerialized data);
    }
}