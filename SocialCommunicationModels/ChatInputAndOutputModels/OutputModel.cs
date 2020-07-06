namespace SocialCommunicationModels.ChatInputAndOutputModels
{
    using CommonLibary.CommonModels;
    using Newtonsoft.Json;
    using SocialCommunicationModels.ChatModels.ConversationModels;
    using SocialCommunicationModels.ChatModels.UserApplicationDetailsModels;
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
        /// Chat User Application Details Model.
        /// </summary>
        /// <seealso cref="UserApplicationDetailsModel"/>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public UserApplicationDetailsModel userApplicationDetailsModel;

        /// <summary>
        /// chat Conversation Output Model.
        /// </summary>
        /// <seealso cref="ChatConversationModel"/>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ChatConversationModel chatConversationModel;

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
