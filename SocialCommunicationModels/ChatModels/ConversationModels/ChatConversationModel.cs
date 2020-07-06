namespace SocialCommunicationModels.ChatModels.ConversationModels
{
    using System;

    /// <summary>
    /// Chat Conversation Model.
    /// </summary>
    /// <seealso cref="ChatInputAndOutputModels.InputModel.chatConversationModel"/>
    /// <seealso cref="ChatInputAndOutputModels.OutputModel.chatConversationModel"/>
    public class ChatConversationModel
    {
        /// <summary>
        /// chat Betweent users --> string formation type FromUser_ToUser.
        /// </summary>
        public string Chat_bwt;
        
        /// <summary>
        /// Conversation id(Unique).
        /// </summary>
        public Int64 ConversationId;
        
        /// <summary>
        /// Chat Conversation Request User Id.
        /// </summary>
        public int ChatRequestByUserId;

        /// <summary>
        /// Conversation Message Total Count.
        /// </summary>
        public Int64 ConversationMesgCount;
        
        /// <summary>
        /// Conversation Total Unread Message Count.
        /// </summary>
        public int UnreadMesgCount;
        
        /// <summary>
        /// Conversation Type --> Group Conversation, One to One Conversation.
        /// </summary>
        public int ConversationType;

        /// <summary>
        /// Conversation is Active or not Defined by bool type.
        /// </summary>
        public bool IsActive;
    }
}

