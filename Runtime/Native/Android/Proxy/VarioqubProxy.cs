#if UNITY_ANDROID
using UnityEngine;

namespace Com.Yandex.Varioqub.Native.Android.Proxy {
    internal static class VarioqubProxy {
        private static readonly AndroidJavaClass NativeClass = new AndroidJavaClass("com.yandex.varioqub.plugin.unity.VarioqubProxy");
        
        public static void InitVarioqubWithAppMetricaAdapter(string settings) {
            NativeClass.CallStatic("initVarioqubWithAppMetricaAdapter", settings);
        }

        public static void FetchConfig(OnFetchCompleteListenerProxy fetchCompleteListenerProxy) {
            NativeClass.CallStatic("fetchConfig", fetchCompleteListenerProxy);
        }

        public static void ActivateConfig() {
            NativeClass.CallStatic("activateConfig");
        }

        public static bool GetBoolean(string key, bool defaultValue) {
            return NativeClass.CallStatic<bool>("getBoolean", key, defaultValue);
        }

        public static double GetDouble(string key, double defaultValue) {
            return NativeClass.CallStatic<double>("getDouble", key, defaultValue);
        }

        public static long GetLong(string key, long defaultValue) {
            return NativeClass.CallStatic<long>("getLong", key, defaultValue);
        }

        public static string GetString(string key, string defaultValue) {
            return NativeClass.CallStatic<string>("getString", key, defaultValue);
        }

        public static string GetId() {
            return NativeClass.CallStatic<string>("getId");
        }

        public static void SetDefaults(string defaultsJsonValue) {
            NativeClass.CallStatic("setDefaults", defaultsJsonValue);
        }

        public static void PutClientFeature(string key, string value) {
            NativeClass.CallStatic("putClientFeature", key, value);
        }

        public static void ClearClientFeatures() {
            NativeClass.CallStatic("clearClientFeatures");
        }

        public static string[] GetAllKeys() {
            return NativeClass.CallStatic<string[]>("getAllKeys");
        }
    }
}
#endif
