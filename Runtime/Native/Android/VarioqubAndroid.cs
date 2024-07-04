#if UNITY_ANDROID
using System.Collections.Generic;
using Com.Yandex.Varioqub.Internal;
using Com.Yandex.Varioqub.Native.Android.Proxy;
using Com.Yandex.Varioqub.Native.Utils.Serializer;
using UnityEngine;

namespace Com.Yandex.Varioqub.Native.Android {
    internal class VarioqubAndroid : IVarioqubNative {

        public void InitVarioqubWithAppMetricaAdapter(VarioqubSettings settings) {
            VarioqubProxy.InitVarioqubWithAppMetricaAdapter(settings.ToJsonString());
        }

        public void FetchConfig(OnFetchCompleteListener.OnSuccessDelegate onSuccessDelegate, OnFetchCompleteListener.OnErrorDelegate onErrorDelegate) {
            VarioqubProxy.FetchConfig(new OnFetchCompleteListenerProxy(onSuccessDelegate, onErrorDelegate));
        }

        public void ActivateConfig() {
            VarioqubProxy.ActivateConfig();
        }

        public bool GetBoolean(string key, bool defaultValue) {
            return VarioqubProxy.GetBoolean(key, defaultValue);
        }

        public double GetDouble(string key, double defaultValue) {
            return VarioqubProxy.GetDouble(key, defaultValue);
        }

        public long GetLong(string key, long defaultValue) {
            return VarioqubProxy.GetLong(key, defaultValue);
        }

        public string GetString(string key, string defaultValue) {
            return VarioqubProxy.GetString(key, defaultValue);
        }

        public string GetId() {
            return VarioqubProxy.GetId();
        }

        public void SetDefaults(IDictionary<string, object> dictionary) {
            VarioqubProxy.SetDefaults(JSONEncoder.Encode(dictionary));
        }

        public void PutClientFeature(string key, string value) {
            VarioqubProxy.PutClientFeature(key, value);
        }

        public void ClearClientFeatures() {
            VarioqubProxy.ClearClientFeatures();
        }

        public string[] GetAllKeys() {
            return VarioqubProxy.GetAllKeys();
        }
    }
}
#endif
