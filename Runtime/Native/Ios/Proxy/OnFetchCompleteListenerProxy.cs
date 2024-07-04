#if UNITY_IPHONE || UNITY_IOS
using System;
using AOT;

namespace Com.Yandex.Varioqub.Native.Ios.Proxy {
    
    internal delegate void VQUFetchCallbackDelegate(IntPtr onSuccessAction, IntPtr onErrorAction, int status, int fetchErrorCode);
    
    internal static class OnFetchCompleteListenerProxy {
        
        [MonoPInvokeCallback(typeof(VQUFetchCallbackDelegate))]
        public static void Callback(IntPtr onSuccessAction, IntPtr onErrorAction, int status, int fetchErrorCode) {

            var onSuccessDelegate = ActionUtils.FromIntPtr<OnFetchCompleteListener.OnSuccessDelegate>(onSuccessAction);
            var onErrorDelegate = ActionUtils.FromIntPtr<OnFetchCompleteListener.OnErrorDelegate>(onErrorAction);
            
            switch (status) {
                case 0: case 2: {
                    onSuccessDelegate?.Invoke();
                    break;
                }
                case 1: {
                    onErrorDelegate?.Invoke(OnFetchCompleteListener.Error.RequestThrottled);
                    break;
                }
                case 3: {
                    onErrorDelegate?.Invoke(GetErrorByFetchErrorCode(fetchErrorCode));
                    break;
                }
                default: {
                    onErrorDelegate?.Invoke(OnFetchCompleteListener.Error.Unknown);
                    break;
                }
            }
        }

        private static OnFetchCompleteListener.Error GetErrorByFetchErrorCode(int fetchErrorCode) {
            return fetchErrorCode switch {
                1 => OnFetchCompleteListener.Error.EmptyResult,
                2 => OnFetchCompleteListener.Error.IdentifiersNull,
                3 => OnFetchCompleteListener.Error.InternalError,
                4 => OnFetchCompleteListener.Error.NetworkError,
                5 => OnFetchCompleteListener.Error.ResponseParseError,
                _ => OnFetchCompleteListener.Error.Unknown
            };
        }
    }
}
#endif
