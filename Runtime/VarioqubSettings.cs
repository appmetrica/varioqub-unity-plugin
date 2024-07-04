using System;
using System.Collections.Generic;

namespace Com.Yandex.Varioqub {
    
    public class VarioqubSettings {
        
        public VarioqubSettings(string clientId) {
            ClientId = clientId;
            ActivateEvent = true;
            ClientFeatures = null;
            Logs = false;
            ThrottleInterval = -1;
            URL = null;
        }

        public string ClientId { get; }

        public bool ActivateEvent { get; set; }

        public IDictionary<string, string> ClientFeatures { get; set; }

        public bool Logs { get; set; }

        public long ThrottleInterval { get; set; }

        public string URL { get; set; }
    }
}
