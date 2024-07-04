package com.yandex.varioqub.plugin.unity;

import android.app.Activity;
import android.util.Log;

import androidx.annotation.NonNull;

import com.yandex.varioqub.analyticadapter.VarioqubConfigAdapter;
import com.yandex.varioqub.appmetricaadapter.AppMetricaAdapter;
import com.yandex.varioqub.config.Varioqub;
import com.unity3d.player.UnityPlayer;

import org.json.JSONException;

import java.util.Set;

public class VarioqubProxy {

    public static void initVarioqubWithAppMetricaAdapter(@NonNull String settingsJson) {
        init(settingsJson, new AppMetricaAdapter(getActivity()));
    }

    public static void fetchConfig(@NonNull OnFetchCompleteListenerProxy proxy) {
        Varioqub.fetchConfig(new OnFetchCompleteListenerProxy.Delegate(proxy));
    }

    public static void activateConfig() {
        Varioqub.activateConfig(null);
    }

    public static void setDefaults(@NonNull String defaultsJsonValue) {
        try {
            Varioqub.setDefaults(JsonUtils.convertJsonStringToMap(defaultsJsonValue));
        } catch (JSONException e) {
            Log.e("VarioqubUnity", "Something went wrong while parsing defaults map", e);
        }
    }

    @NonNull
    public static String getString(@NonNull String key, @NonNull String defaultValue) {
        return Varioqub.getString(key, defaultValue);
    }

    public static double getDouble(@NonNull String key, double defaultValue) {
        return Varioqub.getDouble(key, defaultValue);
    }

    public static long getLong(@NonNull String key, long defaultValue) {
        return Varioqub.getLong(key, defaultValue);
    }

    public static boolean getBoolean(@NonNull String key, boolean defaultValue) {
        return Varioqub.getBoolean(key, defaultValue);
    }

    @NonNull
    public static String getId() {
        return Varioqub.getId();
    }

    public static void putClientFeature(@NonNull String key, @NonNull String value) {
        Varioqub.putClientFeature(key, value);
    }

    public static void clearClientFeatures() {
        Varioqub.clearClientFeatures();
    }

    @NonNull
    public static String[] getAllKeys() {
        Set<String> keys = Varioqub.getAllKeys();
        return keys.toArray(new String[0]);
    }

    private static void init(String settings, VarioqubConfigAdapter adapter) {
        try {
            Varioqub.init(JsonUtils.convertSettingsFromJson(settings), adapter, getActivity());
        } catch (JSONException e) {
            Log.e("VarioqubUnity", "Something went wrong while parsing Varioqub Settings", e);
        }
    }

    private static Activity getActivity() {
        return UnityPlayer.currentActivity;
    }
}
