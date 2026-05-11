using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Shared.Monos
{
    public class OpenableClosable : MonoBehaviour
    {
        public virtual void SetStatus(bool opened)
        {
            if (opened)
            {
                Open();
            }
            else
            {
                Close();
            }
        }
        
        public virtual void Open() {}
        public virtual void Close() {}
    }
}