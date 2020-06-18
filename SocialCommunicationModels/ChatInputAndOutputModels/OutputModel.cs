namespace SocialCommunicationModels.ChatInputAndOutputModels
{
    using CommonLibary.CommonModels;
    using Newtonsoft.Json;
    using SocialCommunicationModels.ChatRegisterModels;
    using SocialCommunicationModels.CommonModels;
    using System.Collections.Generic;

    public class OutputModel : ExecutionStatusEnums
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ChatRegisterUserModel ChatRegisterUserOutput;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<ChatRegisterUserModel> ChatRegisteredUsers;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<ChatRegisterUserModel> Friends;

        public ResponseModel responseModel;
    }






    // ********     reference Code Json Properties ***********
    //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    //// or
    //[JsonProperty("property_name", NullValueHandling = NullValueHandling.Ignore)]

    //// or for all properties in a class
    //[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
}
