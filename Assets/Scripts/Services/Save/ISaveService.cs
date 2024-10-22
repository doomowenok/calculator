namespace Services.Save
{
    public interface ISaveService
    {
        void Save<TData>(TData data) where TData : ISaveLoadable<TData>;
        bool TryLoad<TData>(ref TData data) where TData : ISaveLoadable<TData>;
        void Clear<TData>() where TData : ISaveLoadable<TData>;
        void ClearAll();
    }
}