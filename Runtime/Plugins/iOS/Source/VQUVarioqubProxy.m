
@import Varioqub;
@import MetricaAdapterReflection;
#import "VQUVarioqubUtils.h"
#import "VQUVarioqubProxy.h"

void vqu_initVarioqubWithAppMetricaAdapter(char *clientId, char *settingsJson) {
    VQVarioqubFacade *varioqub = [VQVarioqubFacade sharedVarioqub];
    VQAppmetricaAdapter *adapter = [VQAppmetricaAdapter new];
    VQConfig *config = vqu_parseConfig(settingsJson);
    
    [varioqub initializeWithClientId:vqu_stringFromCString(clientId) config:config idProvider:adapter reporter:adapter];
}

void vqu_fetchConfig(VQUFetchCallbackDelegate delegate, VQUAction onSuccessAction, VQUAction onErrorAction) {
    VQVarioqubFacade *varioqub = [VQVarioqubFacade sharedVarioqub];
    
    [varioqub fetchConfigWithCompletion:^(enum VQFetchStatus status, NSError * _Nullable error) {
        if (delegate) {
            int fetchErrorCode = -1;
            
            if ([NSError.CONFIG_FETCH_DOMAIN isEqualToString:error.domain]) {
                fetchErrorCode = (int) error.code;
            }
            
            delegate(onSuccessAction, onErrorAction, (int) status, fetchErrorCode);
        }
    }];

}

void vqu_activateConfig() {
    [[VQVarioqubFacade sharedVarioqub] activateConfigAndWait];
}

double vqu_getDouble(char *key, double defaultValue) {
    return [[VQVarioqubFacade sharedVarioqub] getDoubleFor:vqu_stringFromCString(key) defaultValue:defaultValue];
}

long vqu_getLong(char *key, long defaultValue) {
    return [[VQVarioqubFacade sharedVarioqub] getLongFor:vqu_stringFromCString(key) defaultValue:defaultValue];
}

char *vqu_getString(char *key, char *defaultValue) {
    VQVarioqubFacade *varioqub = [VQVarioqubFacade sharedVarioqub];
    NSString *stringKey = vqu_stringFromCString(key);
    NSString *stringDefaultValue = vqu_stringFromCString(defaultValue);
    
    NSString *configStringValue = [varioqub getStringFor:stringKey defaultValue:stringDefaultValue];
    
    return vqu_cStringToCsString(configStringValue);
}

bool vqu_getBoolean(char *key, bool defaultValue) {
    return [[VQVarioqubFacade sharedVarioqub] getBoolFor:vqu_stringFromCString(key) defaultValue:defaultValue];
}

void vqu_putClientFeature(char *key, char *value) {

    NSString *stringKey = vqu_stringFromCString(key);
    NSString *stringValue = vqu_stringFromCString(value);
    
    VQMutableClientFeatures *feature = [[[VQVarioqubFacade sharedVarioqub] clientFeatures] mutableCopy];
    [feature setFeature:stringValue forKey:stringKey];
    [[VQVarioqubFacade sharedVarioqub] setClientFeatures:feature];
}

char *vqu_getId() {
    VQVarioqubFacade *varioqub = [VQVarioqubFacade sharedVarioqub];
    
    if (varioqub.varioqubId) {
        return vqu_cStringToCsString(varioqub.varioqubId);
    } else {
        return vqu_cStringToCsString(@"");
    }
}

void vqu_setDefaults(char *defaultsJsonValue) {
    VQVarioqubFacade *varioqub = [VQVarioqubFacade sharedVarioqub];
    
    NSDictionary *dict = vqu_dictionaryFromCString(defaultsJsonValue);
    
    NSMutableDictionary *result = [NSMutableDictionary dictionary];

    for (NSString *key in dict.keyEnumerator) {
        result[key] = [dict[key] description];
    }
    
    [varioqub setDefaultsAndWait:result];
}

char *vqu_getAllKeys() {
    VQVarioqubFacade *varioqub = [VQVarioqubFacade sharedVarioqub];
    
    return vqu_cStringToCsString([[varioqub allKeys].allObjects componentsJoinedByString:@","]);
}

void vqu_clearClientFeatures() {
    VQMutableClientFeatures *feature = [[[VQVarioqubFacade sharedVarioqub] clientFeatures] mutableCopy];
    [feature clearFeatures];
    [[VQVarioqubFacade sharedVarioqub] setClientFeatures:feature];
}
