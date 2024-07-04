
typedef const void *VQUAction;

char *vqu_cStringToCsString(NSString *id);
NSString *vqu_stringFromCString(const char *string);
bool vqu_isDictionaryOrNil(NSDictionary *dictionary);
NSDictionary *vqu_dictionaryFromJSONString(NSString *json);
NSDictionary *vqu_dictionaryFromCString(const char *json);
VQConfig *vqu_parseConfig(const char *json);
