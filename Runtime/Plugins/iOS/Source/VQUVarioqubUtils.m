
@import Varioqub;
#import "VQUVarioqubUtils.h"

char *vqu_cStringToCsString(NSString *id) {
    if (id == nil) return nil;
    const char *cString = [id UTF8String];
    
    char *res = (char *)malloc(strlen(cString) + 1);
    strcpy(res, cString);
    
    return res;
}

NSString *vqu_stringFromCString(const char *string) {
    return string == nil ? nil : [NSString stringWithUTF8String:string];
}

bool vqu_isDictionaryOrNil(NSDictionary *dictionary) {
    return dictionary == nil || [dictionary isKindOfClass:[NSDictionary class]];
}

NSDictionary *vqu_dictionaryFromJSONString(NSString *json) {
    NSError *error = nil;
    NSDictionary *dict = json == nil ? nil : [NSJSONSerialization JSONObjectWithData:[json dataUsingEncoding:NSUTF8StringEncoding]
                                                                             options:0
                                                                               error:&error];
    if (error == nil && vqu_isDictionaryOrNil(dict)) {
        return dict;
    } else {
        [NSException raise:@"Failed parse json" format:@"%@ for json %@", error, json];
    }
}

NSDictionary *vqu_dictionaryFromCString(const char *json) {
    return vqu_dictionaryFromJSONString(vqu_stringFromCString(json));
}

VQConfig *vqu_parseConfig(const char *json) {
    NSDictionary *dict = vqu_dictionaryFromCString(json);
    VQConfig *config = [VQConfig defaultConfig];
    
    NSDictionary *clientFeatures = dict[@"ClientFeatures"];
    
    config.baseURL = [NSURL URLWithString:dict[@"URL"]];
    config.fetchThrottle = [dict[@"ThrottleInterval"] doubleValue] / 1000;
    config.initialClientFeatures = [VQClientFeatures clientFeaturesWith:clientFeatures];
    
    return config;
}
