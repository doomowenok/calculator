using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;

namespace Services.Save
{
    public sealed class JsonSaveService : ISaveService
    {
        public void Save<TData>(TData data) where TData : ISaveLoadable<TData>
        {
            PlayerPrefs.SetString(typeof(TData).Name, data.PrepareForSave());
            PlayerPrefs.Save();
        }

        public bool TryLoad<TData>(ref TData data) where TData : ISaveLoadable<TData>
        {
            if(!PlayerPrefs.HasKey(typeof(TData).Name)) return false;

            string json = PlayerPrefs.GetString(typeof(TData).Name);
            Debug.Log($"Loaded json: {json}");
            TData loadedData = JsonConvert.DeserializeObject<TData>(json);
            data.Load(loadedData);
            return true;
        }

        public void Clear<TData>() where TData : ISaveLoadable<TData>
        {
            PlayerPrefs.DeleteKey(typeof(TData).Name);
            PlayerPrefs.Save();
        }

        public void ClearAll()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}