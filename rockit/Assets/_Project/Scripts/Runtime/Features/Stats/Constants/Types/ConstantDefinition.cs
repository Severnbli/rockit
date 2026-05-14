using System;

namespace _Project.Scripts.Runtime.Features.Stats.Constants.Types
{
    [Serializable]
    public abstract class ConstantDefinition
    {
        public abstract string Name();
        public abstract string Discoverer();
        public abstract string Info();
    }
}