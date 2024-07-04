using System;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Yandex.Varioqub.Native.Dummy {
    internal class VarioqubDummy : IVarioqubNative {
        public void InitVarioqubWithAppMetricaAdapter(VarioqubSettings settings) { }

        public void FetchConfig(OnFetchCompleteListener.OnSuccessDelegate onSuccessDelegate, OnFetchCompleteListener.OnErrorDelegate onErrorDelegate) { }

        public void ActivateConfig() { }
        
        public bool GetBoolean(string key, bool defaultValue) => false;
        
        public double GetDouble(string key, double defaultValue) => 0.0d;

        public long GetLong(string key, long defaultValue) => 0L;

        public string GetString(string key, string defaultValue) => "";

        public string GetId() => "";

        public void SetDefaults(IDictionary<string, object> dictionary) { }
        
        public void PutClientFeature(string key, string value) { }

        public void ClearClientFeatures() { }
        
        public string[] GetAllKeys() => Array.Empty<string>();
    }
}
