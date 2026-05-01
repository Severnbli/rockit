using _Project.Scripts.Modules.Zenject;
using _Project.Scripts.Runtime.Features.Graphics.Animations.Shared.Types;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Configs
{
    public class BaseWindowConfig<T> : ScriptableObjectAutoInstaller<T> where T : BaseWindowConfig<T>
    {
        [SerializeField] private FloatTweenSettings _bodyOpen;
        [SerializeField] private FloatTweenSettings _bodyClose;
        
        public FloatTweenSettings BodyOpen => _bodyOpen;
        public FloatTweenSettings BodyClose => _bodyClose;
    }
}