namespace Services.Save
{
    public interface ISaveLoadable<in TData>
    {
        string PrepareForSave();
        void Load(TData data);
    }
}