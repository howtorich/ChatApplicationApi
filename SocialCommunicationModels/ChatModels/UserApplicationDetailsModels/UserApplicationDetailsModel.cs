namespace SocialCommunicationModels.ChatModels.UserApplicationDetailsModels
{
    using SocialCommunicationModels.ChatRegisterModels;
    using System.Collections.Generic;

    /// <summary>
    /// User Application Model.
    /// </summary>
    public class UserApplicationDetailsModel
    {
        /// <summary>
        /// User Name.
        /// </summary>
        public string UserName;

        /// <summary>
        /// User Online --> False(Ofline) --> True(Online).
        /// </summary>
        public bool Online;

        /// <summary>
        /// User Recent Chat List.
        /// </summary>
        /// <seealso cref="ChatRegisterUserModel"/>
        public List<ChatRegisterUserModel> RecentChatUsers;
    }
}
