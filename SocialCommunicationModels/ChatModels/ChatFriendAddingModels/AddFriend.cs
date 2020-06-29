namespace SocialCommunicationModels.ChatModels.ChatFriendAddingModels
{
    using Newtonsoft.Json;

    /// <summary>
    /// Add Friend to User Model.
    /// </summary>
    public class AddFriend
    {
        /// <summary>
        /// To Whom the Friend should Add as userId.
        /// </summary>
        public int UserId;

        /// <summary>
        /// Friend User Id to Add.
        /// </summary>
        public int AddingFriendUserId;

        /// <summary>
        /// Already Exists Users Frineds Data (PROPERTIE HAS AN INTERNAL USE).
        /// </summary>
        [JsonIgnore]
        public string AddingUserIds;
    }
}
