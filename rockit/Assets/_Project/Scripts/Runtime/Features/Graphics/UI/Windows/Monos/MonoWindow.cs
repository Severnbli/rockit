using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Monos
{
    public class MonoWindow : MonoBehaviour
    {
        public event Action OnOpen;
        public event Action OnClose;

        public bool Opened { get; private set; }

        public async UniTask Open()
        {
            
        }

        public async UniTask Close()
        {
            
        }
    }
}