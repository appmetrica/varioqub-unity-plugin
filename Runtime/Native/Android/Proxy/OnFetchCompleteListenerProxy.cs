#if UNITY_ANDROID
using JetBrains.Annotations;
using UnityEngine;

namespace Com.Yandex.Varioqub.Native.Android.Proxy {
    internal class OnFetchCompleteListenerProxy : AndroidJavaProxy {
        [NotNull]
        private readonly OnFetchCompleteListener.OnSuccessDelegate _onSuccessDelegate;
        [CanBeNull]
        private readonly OnFetchCompleteListener.OnErrorDelegate _onErrorDelegate;

        public OnFetchCompleteListenerProxy(
            [NotNull] OnFetchCompleteListener.OnSuccessDelegate onSuccessDelegate,
            [CanBeNull] OnFetchCompleteListener.OnErrorDelegate onErrorDelegate
        ) : base("com.yandex.varioqub.plugin.unity.OnFetchCompleteListenerProxy") {
            _onSuccessDelegate = onSuccessDelegate;
            _onErrorDelegate = onErrorDelegate;
        }

        void onSuccess() {
            _onSuccessDelegate();
        }

        void onError([NotNull] string error) {
            _onErrorDelegate?.Invoke(GetError(error));
        }

        private static OnFetchCompleteListener.Error GetError([NotNull] string str) {
            return str switch {
                "EMPTY_RESULT" => OnFetchCompleteListener.Error.EmptyResult,
                "IDENTIFIERS_NULL" => OnFetchCompleteListener.Error.IdentifiersNull,
                "RESPONSE_PARSE_ERROR" => OnFetchCompleteListener.Error.ResponseParseError,
                "REQUEST_THROTTLED" => OnFetchCompleteListener.Error.RequestThrottled,
                "NETWORK_ERROR" => OnFetchCompleteListener.Error.NetworkError,
                "INTERNAL_ERROR" => OnFetchCompleteListener.Error.InternalError,
                _ => OnFetchCompleteListener.Error.Unknown,
            };
        }
    }
}
#endif
