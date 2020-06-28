namespace SocialCommunicationModels.ChatInputAndOutputModels
{
    using SocialCommunicationModels.ChatModels.ChatFriendAddingModels;
    using SocialCommunicationModels.ChatRegisterModels;
    using static SocialCommunicationModels.CommonModels.ChatApiActionEnums;

    public class InputModel
    {
        public ChatApiActions ApiAction;

        //public ChatInputModel ChatInputModel;

        public ChatRegisterUserModel chatRegisterUserModel;

        public AddFriend addFriend;
    }
}
