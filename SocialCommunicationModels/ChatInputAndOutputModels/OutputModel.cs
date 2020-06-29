namespace SocialCommunicationModels.ChatInputAndOutputModels
{
    using CommonLibary.CommonModels;
    using Newtonsoft.Json;
    using SocialCommunicationModels.ChatRegisterModels;
    using SocialCommunicationModels.CommonModels;
    using System.Collections.Generic;

    /// <summary>
    /// Chat Common Output Model.
    /// </summary>
    public class OutputModel : ExecutionStatusEnums
    {
        /// <summary>
        /// Chat Register user Output Model.
        /// </summary>
        /// <seealso cref="ChatRegisterUserModel"/>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ChatRegisterUserModel ChatRegisterUserOutput;

        /// <summary>
        /// Chat Register users List Model.
        /// </summary>
        /// <seealso cref="ChatRegisterUserModel"/>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<ChatRegisterUserModel> ChatRegisteredUsers;

        /// <summary>
        /// Chat User Friends Model.
        /// </summary>
        /// <seealso cref="ChatRegisterUserModel"/>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<ChatRegisterUserModel> Friends;

        /// <summary>
        /// Chat Response Model.
        /// </summary>
        /// <seealso cref="ResponseModel"/>
        public ResponseModel responseModel;
    }






    // ********     reference Code Json Properties ***********
    //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    //// or
    //[JsonProperty("property_name", NullValueHandling = NullValueHandling.Ignore)]

    //// or for all properties in a class
    //[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
}
