using Infrastructure.MVP;
using Services.Save;
using UnityEngine;

namespace Core.Features.Info
{
    public sealed class InfoModel : BaseModel, ISaveLoadable<InfoModel>
    {
        public string PrepareForSave()
        {
            return JsonUtility.ToJson(this);
        }

        public void Load(InfoModel data) { }
    }
}