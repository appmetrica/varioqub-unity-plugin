using System;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_ANDROID && !UNITY_EDITOR
using Com.Yandex.Varioqub.Native.Android;
#elif (UNITY_IPHONE || UNITY_IOS) && !UNITY_EDITOR
using Com.Yandex.Varioqub.Native.Ios;
#else
using Com.Yandex.Varioqub.Native.Dummy;
#endif

namespace Com.Yandex.Varioqub {
    public static class Varioqub {
        private static readonly IVarioqubNative VarioqubNative;
        
        static Varioqub() {
#if UNITY_ANDROID && !UNITY_EDITOR
            VarioqubNative = new VarioqubAndroid();
#elif (UNITY_IPHONE || UNITY_IOS) && !UNITY_EDITOR
            VarioqubNative = new VarioqubIos();
#else
            VarioqubNative = new VarioqubDummy();
#endif
        }

        public static void InitVarioqubWithAppMetricaAdapter(VarioqubSettings settings) {
            VarioqubNative.InitVarioqubWithAppMetricaAdapter(settings);
        }

        public static void Fetch(
            OnFetchCompleteListener.OnSuccessDelegate onSuccessDelegate,
            OnFetchCompleteListener.OnErrorDelegate onErrorDelegate
        ) {
            VarioqubNative.FetchConfig(onSuccessDelegate, onErrorDelegate);
        }

        public static void ActivateConfig() {
            VarioqubNative.ActivateConfig();
        }

        public static string GetString(string key, string defaultValue) {
            return VarioqubNative.GetString(key, defaultValue);
        }

        public static bool GetBoolean(string key, bool defaultValue) {
            return VarioqubNative.GetBoolean(key, defaultValue);
        }

        public static long GetLong(string key, long defaultValue) {
            return VarioqubNative.GetLong(key, defaultValue);
        }
        
        public static double GetDouble(string key, double defaultValue) {
            return VarioqubNative.GetDouble(key, defaultValue);
        }

        public static string GetId() {
            return VarioqubNative.GetId();
        }

        public static void PutClientFeature(string key, string value) {
            VarioqubNative.PutClientFeature(key, value);
        }

        public static void ClearClientFeatures() {
            VarioqubNative.ClearClientFeatures();
        }

        public static string[] GetAllKeys() {
            return VarioqubNative.GetAllKeys();
        }

        public static void SetDefaults(IDictionary<string, object> defaults) {
            VarioqubNative.SetDefaults(defaults);
        }
    }
}
