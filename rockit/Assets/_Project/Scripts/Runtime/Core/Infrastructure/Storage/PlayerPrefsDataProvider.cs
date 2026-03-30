using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Storage
{
    public class PlayerPrefsDataProvider : IDataProvider
    {
        public string GetData(string key)
        {
            return PlayerPrefs.GetString(key);
        }

        public void PutData(string key, string data)
        {
            PlayerPrefs.SetString(key, data);
        }
    }
}