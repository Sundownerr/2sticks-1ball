using UnityEngine.Scripting;

namespace SDW.SaveLoad
{
    [Preserve]
    public class JsonAotSetup
    {
        [Preserve]
        private void Setup()
        {
            var jsonSerializer = new JsonSerializer();
            var jsonSerializationContainer = new JsonSerializationContainer(jsonSerializer);
      
            jsonSerializationContainer.Add("", true);
            jsonSerializationContainer.Add("", 1);
            jsonSerializationContainer.Add("", 1f);
            jsonSerializationContainer.Add("", 1d);
            jsonSerializationContainer.Add("", "");
            
            jsonSerializationContainer.Get<bool>("");
            jsonSerializationContainer.Get<int>("");
            jsonSerializationContainer.Get<float>("");
            jsonSerializationContainer.Get<decimal>("");
            jsonSerializationContainer.Get<string>("");

            jsonSerializer.Serialize(true);
            jsonSerializer.Serialize(1);
            jsonSerializer.Serialize(1f);
            jsonSerializer.Serialize(1d);
            jsonSerializer.Serialize("");

            jsonSerializer.Deserialize<bool>("");
            jsonSerializer.Deserialize<int>("");
            jsonSerializer.Deserialize<float>("");
            jsonSerializer.Deserialize<decimal>("");
            jsonSerializer.Deserialize<string>("");
        }
    }
}