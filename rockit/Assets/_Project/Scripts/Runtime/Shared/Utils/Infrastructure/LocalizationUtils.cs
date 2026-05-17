using System.Collections.Generic;
using System.IO;
using System.Linq;
using _Project.Scripts.Runtime.Core.Infrastructure.Localization;
using _Project.Scripts.Runtime.Core.Infrastructure.Localization.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Localization.Types;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using _Project.Scripts.Runtime.Shared.Utils.Shared;
using Cysharp.Threading.Tasks;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using Newtonsoft.Json;
using UnityEngine;

namespace _Project.Scripts.Runtime.Shared.Utils.Infrastructure
{
    public static class LocalizationUtils
    {
        public static string GetFileName()
        {
            return $"{LocalizationContracts.LanguageDataFileName}.json";
        }

        public static string GetLanguageDataPath()
        {
            return StreamingAssetsUtils.GetPath(GetFileName());
        }

        public static void WriteLanguageData(string json)
        {
            StreamingAssetsUtils.Write(GetFileName(), json);
        }

        public static void WriteLanguageData(List<LanguageData> languageData)
        {
            var json = JsonConvert.SerializeObject(languageData, Formatting.Indented);
            WriteLanguageData(json);
        }

        public static string GetLanguageDataJson()
        {
            return StreamingAssetsUtils.Read(GetFileName());
        }

        public static async UniTask<string> GetLanguageDataJsonAsync()
        {
            return await StreamingAssetsUtils.ReadAsync(GetFileName());
        }

        private static List<LanguageData> ConstructLanguageDataList(string json)
        {
            return JsonConvert.DeserializeObject<List<LanguageData>>(json) ?? new List<LanguageData>();
        }

        public static List<LanguageData> GetLanguageDataList()
        {
            var json = GetLanguageDataJson();
            return ConstructLanguageDataList(json);
        }

        public static async UniTask<List<LanguageData>> GetLanguageDataListAsync()
        {
            var json = await GetLanguageDataJsonAsync();
            return ConstructLanguageDataList(json);
        }

        private static Dictionary<string, LanguageData> ConstructLanguageDataDictionary(List<LanguageData> languageData)
        {
            return languageData.ToDictionary(k => k.LanguageCode, v => v);
        }

        public static Dictionary<string, LanguageData> GetLanguageDataDictionary()
        {
            var list = GetLanguageDataList();
            return ConstructLanguageDataDictionary(list);
        }

        public static async UniTask<Dictionary<string, LanguageData>> GetLanguageDataDictionaryAsync()
        {
            var list = await GetLanguageDataListAsync();
            return ConstructLanguageDataDictionary(list);
        }

        public static ProtoEntity CreateChangeLanguageRequest(RequestsAspect aspect, ChangeLanguageRequest prepared)
        {
            return aspect.CreateRequest(aspect.LocalizationRequestsAspect.ChangeLanguageRequestPool, prepared: prepared);
        }
        
        public static ProtoEntity CreateUpdateLocalizationItemRequest(RequestsAspect aspect, ProtoPackedEntityWithWorld packed)
        {
            return aspect.CreateRequest(aspect.LocalizationRequestsAspect.UpdateLocalizationItemRequestPool, packed);
        }

        public static ProtoEntity CreateLocalizationUpdatedRequest(RequestsAspect aspect)
        {
            return aspect.CreateRequest(aspect.LocalizationRequestsAspect.LocalizationUpdatedRequestPool);
        }
    }
}