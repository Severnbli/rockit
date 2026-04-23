using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.Runtime.Core.Infrastructure.Localization;
using _Project.Scripts.Runtime.Core.Infrastructure.Localization.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Localization.Types;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Shared.Extensions;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using Newtonsoft.Json;
using UnityEngine;

namespace _Project.Scripts.Runtime.Shared.Utils
{
    public static class LocalizationUtils
    {
        public static string GetLanguageDataPath()
        {
            return System.IO.Path.Combine(Application.streamingAssetsPath, 
                $"{LocalizationContracts.LanguageDataFileName}.json");
        }

        public static void WriteLanguageData(string json)
        {
            var path = GetLanguageDataPath();
            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(path) ?? "");
            System.IO.File.WriteAllText(path, json);
        }

        public static void WriteLanguageData(List<LanguageData> languageData)
        {
            var json = JsonConvert.SerializeObject(languageData, Formatting.Indented);
            WriteLanguageData(json);
        }

        public static string GetLanguageDataJson()
        {
            var path = GetLanguageDataPath();
            return !System.IO.File.Exists(path) ? "" : System.IO.File.ReadAllText(path);
        }

        public static List<LanguageData> GetLanguageDataList()
        {
            var json = GetLanguageDataJson();
            return JsonConvert.DeserializeObject<List<LanguageData>>(json) ?? new List<LanguageData>();
        }

        public static Dictionary<string, LanguageData> GetLanguageDataDictionary()
        {
            var list = GetLanguageDataList();
            var dict = list.ToDictionary(k => k.LanguageCode, v => v);
            return dict;
        }

        public static ProtoEntity CreateChangeLanguageRequest(RequestsAspect aspect, ChangeLanguageRequest prepared)
        {
            return aspect.CreateRequest(aspect.LocalizationRequestsAspect.ChangeLanguageRequestPool, prepared: prepared);
        }
        
        public static ProtoEntity CreateUpdateLocalizationItemRequest(RequestsAspect aspect, ProtoPackedEntityWithWorld packed)
        {
            return aspect.CreateRequest(aspect.LocalizationRequestsAspect.UpdateLocalizationItemRequestPool, packed);
        }
    }
}