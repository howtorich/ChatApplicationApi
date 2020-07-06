namespace SocialCommunicationModels.CommonModels
{
    /// <summary>
    /// Api End Point Action Type Enums.
    /// </summary>
    public class ChatApiActionEnums
    {
        /// <summary>
        /// Api Action Enum Based on this Enum Api End Point Action May Differ.
        /// </summary>
        public enum ChatApiActions
        {
            /// <summary>
            /// Chat User Registration Action Type.
            /// </summary>
            Registration = 100,

            /// <summary>
            /// Get Global Chat Users List Action Type.
            /// </summary>
            GetGolbalChatUsersList = 101,

            /// <summary>
            /// Get User Friends List Action Type.
            /// </summary>
            GetUserFriendsList = 102,

            /// <summary>
            /// Get Chat Users Without Friends of Particular User Action Type.
            /// </summary>
            GetUsersWithoutFriends = 103,

            /// <summary>
            /// Add Friend to user Action Type.
            /// </summary>
            AddFriend = 104,

            /// <summary>
            /// Get user Application Details Api Action Type.
            /// </summary>
            GetUserApplicationDetails = 105,

            /// <summary>
            /// Get Chat Conversation Info Action Type.
            /// </summary>
            GetChatConverstionInfo = 106,
        }
    }
}
