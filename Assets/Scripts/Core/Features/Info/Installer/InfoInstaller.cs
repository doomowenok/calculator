using Zenject;

namespace Core.Features.Info.Installer
{
    public sealed class InfoInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<InfoModel>()
                .ToSelf()
                .AsSingle()
                .Lazy();
        }
    }
}