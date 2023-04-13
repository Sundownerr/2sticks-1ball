namespace SDW.SaveLoad
{
    public interface ISaveData<TContainer>
    {
        void SaveTo(TContainer container);
        void LoadFrom(TContainer container);
        void OnDefault();
    }
}