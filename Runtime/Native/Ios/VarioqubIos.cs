#if UNITY_IPHONE || UNITY_IOS
using System.Collections.Generic;
using Com.Yandex.Varioqub.Internal;
using Com.Yandex.Varioqub.Native.Ios.Proxy;
using Com.Yandex.Varioqub.Native.Utils.Serializer;

namespace Com.Yandex.Varioqub.Native.Ios {
    internal class VarioqubIos : IVarioqubNative {

        public void InitVarioqubWithAppMetricaAdapter(VarioqubSettings settings) {
            VarioqubProxy.vqu_initVarioqubWithAppMetricaAdapter(settings.ClientId, settings.ToJsonString());
        }

        public void FetchConfig(OnFetchCompleteListener.OnSuccessDelegate onSuccessDelegate, OnFetchCompleteListener.OnErrorDelegate onErrorDelegate) {
            VarioqubProxy.vqu_fetchConfig(OnFetchCompleteListenerProxy.Callback, ActionUtils.ToIntPtr(onSuccessDelegate), ActionUtils.ToIntPtr(onErrorDelegate));
        }

        public void ActivateConfig() {
            VarioqubProxy.vqu_activateConfig();
        }

        public bool GetBoolean(string key, bool defaultValue) {
            return VarioqubProxy.vqu_getBoolean(key, defaultValue);
        }

        public double GetDouble(string key, double defaultValue) {
            return VarioqubProxy.vqu_getDouble(key, defaultValue);
        }

        public long GetLong(string key, long defaultValue) {
            return VarioqubProxy.vqu_getLong(key, defaultValue);
        }

        public string GetString(string key, string defaultValue) {
            return VarioqubProxy.vqu_getString(key, defaultValue);
        }

        public string GetId() {
            return VarioqubProxy.vqu_getId();
        }

        public void SetDefaults(IDictionary<string, object> dictionary) {
            VarioqubProxy.vqu_setDefaults(JSONEncoder.Encode(dictionary));
        }

        public void PutClientFeature(string key, string value) {
            VarioqubProxy.vqu_putClientFeature(key, value);
        }

        public void ClearClientFeatures() {
            VarioqubProxy.vqu_clearClientFeatures();
        }

        public string[] GetAllKeys() {
            return VarioqubProxy.vqu_getAllKeys().Split(',');
        }
    }
}
#endif
