namespace SDW.SaveLoad
{
    public interface ISerializer<TSerialized>
    {
        TSerialized Serialize<T>(T data);
        T Deserialize<T>(TSerialized serialized);
    }
}