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
            switch (fetchErrorCode) {
                case 1:
                    return OnFetchCompleteListener.Error.EmptyResult;
                case 2:
                    return OnFetchCompleteListener.Error.IdentifiersNull;
                case 3:
                    return OnFetchCompleteListener.Error.InternalError;
                case 4:
                    return OnFetchCompleteListener.Error.NetworkError;
                case 5:
                    return OnFetchCompleteListener.Error.ResponseParseError;
                default:
                    return OnFetchCompleteListener.Error.Unknown;
            }
        }
    }
}
#endif
