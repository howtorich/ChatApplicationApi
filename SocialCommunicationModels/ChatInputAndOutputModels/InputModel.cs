namespace SocialCommunicationModels.ChatInputAndOutputModels
{
    using SocialCommunicationModels.ChatModels.ChatFriendAddingModels;
    using SocialCommunicationModels.ChatModels.ConversationModels;
    using SocialCommunicationModels.ChatRegisterModels;
    using SocialCommunicationModels.CommonModels;

    /// <summary>
    /// Chat Commmon Input Model.
    /// </summary>
    public class InputModel
    {
        /// <summary>
        /// Api Action Type --> Based on this API End point Action May Differ.
        /// </summary>
        /// <seealso cref="ChatApiActionEnums.ChatApiActions"/>
        public ChatApiActionEnums.ChatApiActions ApiAction;

        //public ChatInputModel ChatInputModel;

        /// <summary>
        /// Char Register User Model.
        /// </summary>
        /// <seealso cref="ChatRegisterUserModel"/>
        public ChatRegisterUserModel chatRegisterUserModel;

        /// <summary>
        /// Add friend to User Model.
        /// </summary>
        /// <seealso cref="AddFriend"/>
        public AddFriend addFriend;

        /// <summary>
        /// Chat Conversation Model.
        /// </summary>
        /// <seealso cref="ChatConversationModel"/>
        public ChatConversationModel chatConversationModel;
    }
}
