using _Project.Scripts.Modules.Zenject;
using _Project.Scripts.Runtime.Core.Infrastructure.Animations.Tools.Pipeline.Core;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Configs
{
    public class BaseWindowConfig<T> : ScriptableObjectAutoInstaller<T> where T : BaseWindowConfig<T>
    {
        [SerializeField] private TweenPipeline _bodyOpen;
        [SerializeField] private TweenPipeline _bodyClose;
        
        public TweenPipeline BodyOpen => _bodyOpen;
        public TweenPipeline BodyClose => _bodyClose;
    }
}