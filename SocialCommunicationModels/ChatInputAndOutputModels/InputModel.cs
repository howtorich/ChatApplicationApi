namespace SocialCommunicationModels.ChatInputAndOutputModels
{
    using SocialCommunicationModels.ChatModels;
    using SocialCommunicationModels.ChatRegisterModels;
    using static SocialCommunicationModels.CommonModels.ChatApiActionEnums;

    public class InputModel
    {
        public ChatApiActions ApiAction;

        //public ChatInputModel ChatInputModel;

        public ChatRegisterUserModel chatRegisterUserModel;
    }
}
