
using System.Collections.Generic;

namespace Com.Yandex.Varioqub {
    public interface IVarioqubNative {
        void InitVarioqubWithAppMetricaAdapter(VarioqubSettings settings);

        void FetchConfig(OnFetchCompleteListener.OnSuccessDelegate onSuccessDelegate, OnFetchCompleteListener.OnErrorDelegate onErrorDelegate);

        void ActivateConfig();

        bool GetBoolean(string key, bool defaultValue);

        double GetDouble(string key, double defaultValue);

        long GetLong(string key, long defaultValue);

        string GetString(string key, string defaultValue);

        string GetId();

        void SetDefaults(IDictionary<string, object> dictionary);

        void PutClientFeature(string key, string value);

        void ClearClientFeatures();

        string[] GetAllKeys();
    }
}
