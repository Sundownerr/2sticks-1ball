using  Newtonsoft.Json;

namespace SDW.SaveLoad
{
    public class JsonSerializer : ISerializer<string>
    {
        public string Serialize<T>(T data)
        {
            return JsonConvert.SerializeObject(data, Formatting.None);
        }

        public T Deserialize<T>(string serialized)
        {
            return JsonConvert.DeserializeObject<T>(serialized);
        }
    }
}