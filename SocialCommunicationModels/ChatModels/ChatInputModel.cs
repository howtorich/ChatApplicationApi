namespace SocialCommunicationModels.ChatModels
{
    using CommonModels;
    using Newtonsoft.Json;

    public class ChatInputModel : AppCarryModel
    {
        [JsonProperty("receiveruserid")]
        public int ReceiverUserId;

        [JsonProperty("messagetosend")]
        public string MessageToSend;

        [JsonProperty("attachment")]
        public byte[] Attachment;
    }
}
