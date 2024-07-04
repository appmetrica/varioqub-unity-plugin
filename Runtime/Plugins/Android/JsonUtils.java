package com.yandex.varioqub.plugin.unity;

import android.text.TextUtils;

import com.yandex.varioqub.config.VarioqubSettings;

import org.json.JSONException;
import org.json.JSONObject;

import java.util.HashMap;
import java.util.Iterator;
import java.util.Map;

class JsonUtils {

    public static Map<String, String> convertJsonStringToMap(String jsonValue) throws JSONException {
        final JSONObject jsonObject = new JSONObject(jsonValue);

        final Iterator<String> keys = jsonObject.keys();
        final Map<String, String> resultMap = new HashMap<>();

        while (keys.hasNext()) {
            final String key = keys.next();
            final String value = jsonObject.get(key).toString();

            resultMap.put(key, value);
        }

        return resultMap;
    }

    public static VarioqubSettings convertSettingsFromJson(String jsonValue) throws JSONException {
        final JSONObject varioqubSettingsJson = new JSONObject(jsonValue);

        final String clientId = varioqubSettingsJson.getString("ClientId");
        final VarioqubSettings.Builder builder = new VarioqubSettings.Builder(clientId);

        if (varioqubSettingsJson.has("URL")) {
            builder.withUrl(varioqubSettingsJson.getString("URL"));
        }

        if (varioqubSettingsJson.has("ThrottleInterval")) {
            builder.withThrottleInterval(varioqubSettingsJson.getLong("ThrottleInterval"));
        }

        if (varioqubSettingsJson.optBoolean("Logs")) {
            builder.withLogs();
        }

        if (varioqubSettingsJson.has("ActivateEvent")) {
            builder.withActivateEvent(varioqubSettingsJson.getBoolean("ActivateEvent"));
        }

        final String clientFeaturesJson = varioqubSettingsJson.optString("ClientFeatures");

        if (!TextUtils.isEmpty(clientFeaturesJson)) {
            final Map<String, String> clientFeaturesMap = convertJsonStringToMap(clientFeaturesJson);

            for (Map.Entry<String, String> entry : clientFeaturesMap.entrySet()) {
                builder.withClientFeature(entry.getKey(), entry.getValue());
            }
        }

        return builder.build();
    }
}
