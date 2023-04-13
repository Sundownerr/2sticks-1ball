# Save &amp; Load data in Unity

# Usage
```csharp

// some data you need to save
public class PlayerData : IJsonSaveData
{
    // keys to access saved values
    private const string TutorialCompletedKey = "TutorialCompleted";
    private const string CustomDataKey = "CustomData";
    private const string MoneyKey = "Money";

    public bool TutorialCompleted { get; set; }
    public CustomData CustomData { get; set; }
    public int Money { get; set; }

    
    // called before data is saved
    // serialization container hold, serialize, and deserialize given data
    public void SaveTo(IJsonSerializationContainer container) 
    {
        container.Add(TutorialCompletedKey, TutorialCompleted);
        container.Add(CustomDataKey, CustomData);
        container.Add(MoneyKey, Money);
    }

    // called after data is loaded
    public void LoadFrom(IJsonSerializationContainer container)
    {
        TutorialCompleted = container.Get<bool>(TutorialCompletedKey);
        CustomData = container.Get<CustomData>(CustomDataKey);
        Money = container.Get<int>(MoneyKey);
    }

    // called when no entry of this type is found
    public void OnDefault()
    {
        Money = 42;
    }
}
```

```csharp
public class EntryPoint : MonoBehaviour
{
    private void Start()
    {
        // create serializer and container
        var serializer = new JsonSerializer();
        var serializationContainer = new JsonSerializationContainer(serializer);

        // create your data you need to save and load
        var playerData = new PlayerData();
        var worldData = new WorldData();

        // create wrappers for your data
        var playerSave = new JsonSaveWrapper<PlayerData>("PlayerData", playerData);
        var worldSave = new JsonSaveWrapper<WorldData>("WorldData", worldData);
        var saves = new IJsonSaveWrapper[] { playerSave, worldSave, };

        // create saver and loader
        var saver = new JsonPrefsSaver(serializationContainer, saves);
        var loader = new JsonPrefsLoader(serializationContainer, saves);

        // load and save your data
        loader.Load();
        saver.Save();
    }
}
```
