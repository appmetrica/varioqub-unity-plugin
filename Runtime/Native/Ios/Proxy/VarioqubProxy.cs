#if UNITY_IPHONE || UNITY_IOS
using System;
using System.Runtime.InteropServices;

namespace Com.Yandex.Varioqub.Native.Ios.Proxy {
    internal static class VarioqubProxy {

        [DllImport("__Internal")]
        public static extern void vqu_initVarioqubWithAppMetricaAdapter(string clientId, string settingsJson);

        [DllImport("__Internal")]
        public static extern void vqu_fetchConfig(VQUFetchCallbackDelegate @delegate, IntPtr onSuccessAction, IntPtr onErrorAction);

        [DllImport("__Internal")]
        public static extern void vqu_activateConfig();

        [DllImport("__Internal")]
        public static extern bool vqu_getBoolean(string key, bool defaultValue);

        [DllImport("__Internal")]
        public static extern double vqu_getDouble(string key, double defaultValue);

        [DllImport("__Internal")]
        public static extern long vqu_getLong(string key, long defaultValue);

        [DllImport("__Internal")]
        public static extern string vqu_getString(string key, string defaultValue);

        [DllImport("__Internal")]
        public static extern string vqu_getId();

        [DllImport("__Internal")]
        public static extern void vqu_setDefaults(string defaultsJsonValue);

        [DllImport("__Internal")]
        public static extern void vqu_putClientFeature(string key, string value);

        [DllImport("__Internal")]
        public static extern void vqu_clearClientFeatures();

        [DllImport("__Internal")]
        public static extern string vqu_getAllKeys();
    }
}
#endif
