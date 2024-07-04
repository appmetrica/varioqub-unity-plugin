package com.yandex.varioqub.plugin.unity;

import androidx.annotation.NonNull;

import com.yandex.varioqub.config.FetchError;
import com.yandex.varioqub.config.OnFetchCompleteListener;

public interface OnFetchCompleteListenerProxy {

    void onError(@NonNull String reason);

    void onSuccess();

    class Delegate implements OnFetchCompleteListener {

        private final OnFetchCompleteListenerProxy proxy;

        public Delegate(OnFetchCompleteListenerProxy proxy) {
            this.proxy = proxy;
        }

        @Override
        public void onError(@NonNull String s, @NonNull FetchError fetchError) {
            proxy.onError(fetchErrorToString(fetchError));
        }

        @Override
        public void onSuccess() {
            proxy.onSuccess();
        }

        private String fetchErrorToString(FetchError error) {
            switch (error) {

                case EMPTY_RESULT:
                    return "EMPTY_RESULT";
                case IDENTIFIERS_NULL:
                    return "IDENTIFIERS_NULL";
                case RESPONSE_PARSE_ERROR:
                    return "RESPONSE_PARSE_ERROR";
                case REQUEST_THROTTLED:
                    return "REQUEST_THROTTLED";
                case NETWORK_ERROR:
                    return "NETWORK_ERROR";
                case INTERNAL_ERROR:
                    return "INTERNAL_ERROR";
                default:
                    return "";
            }
        }
    }
}
