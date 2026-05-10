using _Project.Scripts.Runtime.Core.Infrastructure.Animations.Tools.Pipeline.Core;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Configs
{
    public class BaseWindowConfig : SerializedScriptableObject
    {
        [SerializeField] private TweenPipeline _bodyOpen;
        [SerializeField] private TweenPipeline _bodyClose;
        
        public TweenPipeline BodyOpen => _bodyOpen;
        public TweenPipeline BodyClose => _bodyClose;
    }
}