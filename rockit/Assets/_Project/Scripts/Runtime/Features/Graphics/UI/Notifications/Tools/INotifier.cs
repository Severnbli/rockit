using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Notifications.Tools
{
    public interface INotifier
    {
        UniTask ShowCenterNotification(string text);
    }
}