using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Sirenix.Utilities;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Modules.Zenject
{
    [ShowOdinSerializedPropertiesInInspector]
    public class ScriptableObjectAutoInstaller<T> : ScriptableObjectInstaller, ISerializationCallbackReceiver
        where T : ScriptableObjectAutoInstaller<T>
    {
        [SerializeField]
        [HideInInspector]
        private SerializationData serializationData;
        
        public sealed override void InstallBindings()
        {
            RegisterBindings();
            Container.Bind<T>().FromInstance((T) this).AsSingle();
        }
        
        protected virtual void RegisterBindings() {}
        
        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            if (this.SafeIsUnityNull()) return;
            UnitySerializationUtility.DeserializeUnityObject(this, ref serializationData);
            OnAfterDeserialize();
        }

        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
            if (this.SafeIsUnityNull()) return;
            OnBeforeSerialize();
            UnitySerializationUtility.SerializeUnityObject(this, ref serializationData);
        }

        protected virtual void OnAfterDeserialize()
        {
        }

        protected virtual void OnBeforeSerialize()
        {
        }

#if UNITY_EDITOR
        [HideInTables]
        [OnInspectorGUI]
        [PropertyOrder(-2.1474836E+09f)]
        private void InternalOnInspectorGUI()
        {
            EditorOnlyModeConfigUtility.InternalOnInspectorGUI(this);
        }
#endif
    }
}