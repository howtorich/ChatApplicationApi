namespace SocialCommunicationModels.ChatModels.ChatFriendAddingModels
{
    using Newtonsoft.Json;

    public class AddFriend
    {
        public int UserId;

        public int AddingFriendUserId;

        [JsonIgnore]
        public string AddingUserIds;
    }
}
