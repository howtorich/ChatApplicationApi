namespace SocialCommunicationModels.CommonModels
{
    using Newtonsoft.Json;

    public class AppCarryModel
    {
        [JsonProperty("userid")]
        public int UserId;

        [JsonProperty("username")]
        public string UserName;

        [JsonProperty("sessiontoken")]
        public int SessionToken;

        [JsonProperty("sessionguid")]
        public string SessionGuid;

        [JsonProperty("userinternalip")]
        public string UserInternalIp;

        [JsonProperty("userdevicetype")]
        public string UserDeviceType;

        [JsonProperty("userexternalip")]
        public string UserExternalIp;

        [JsonProperty("userdatetime")]
        public string UserDateTime;
    }
}
