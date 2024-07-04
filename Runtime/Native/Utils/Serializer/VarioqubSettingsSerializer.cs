using System.Collections.Generic;
using Com.Yandex.Varioqub.Internal;
using JetBrains.Annotations;

namespace Com.Yandex.Varioqub.Native.Utils.Serializer {
    internal static class VarioqubSettingsSerializer {
        [NotNull]
        public static string ToJsonString([NotNull] this VarioqubSettings self) {
            return JSONEncoder.Encode(new Dictionary<string, object> {
                { "ClientId", self.ClientId },
                { "URL", self.URL },
                { "ClientFeatures", self.ClientFeatures },
                { "Logs", self.Logs },
                { "ThrottleInterval", self.ThrottleInterval },
                { "ActivateEvent", self.ActivateEvent }
            });
        }
    }
}
