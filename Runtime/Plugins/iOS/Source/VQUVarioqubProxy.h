
@class VQVarioqubFacade;
@class VQAppmetricaAdapter;

typedef void (*VQUFetchCallbackDelegate)(VQUAction onSuccessAction, VQUAction onErrorAction, const int status, const int errorCode);

void vqu_initVarioqubWithAppMetricaAdapter(char *clientId, char *settingsJson);
void vqu_fetchConfig(VQUFetchCallbackDelegate delegate, VQUAction onSuccessAction, VQUAction onErrorAction);
void vqu_activateConfig();
bool vqu_getBoolean(char *key, bool defaultValue);
double vqu_getDouble(char *key, double defaultValue);
long vqu_getLong(char *key, long defaultValue);
char *vqu_getString(char *key, char *defaultValue);
void vqu_putClientFeature(char *key, char *value);
void vqu_clearClientFeatures();
char *vqu_getAllKeys();
char *vqu_getId();
void vqu_setDefaults(char *defaultsJsonValue);
