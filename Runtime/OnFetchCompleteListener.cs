namespace Com.Yandex.Varioqub {
    public static class OnFetchCompleteListener {
        public delegate void OnSuccessDelegate();
        public delegate void OnErrorDelegate(Error error);

        public enum Error {
            EmptyResult,
            IdentifiersNull,
            ResponseParseError,
            RequestThrottled,
            NetworkError,
            InternalError,
            Unknown,
        }
    }
}
