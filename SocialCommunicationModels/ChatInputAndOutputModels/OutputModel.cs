namespace SocialCommunicationModels.ChatInputAndOutputModels
{
    using CommonLibary.CommonModels;
    using SocialCommunicationModels.ChatRegisterModels;
    using SocialCommunicationModels.CommonModels;
    using System.Collections.Generic;

    public class OutputModel : ExecutionStatusEnums
    {
        public ChatRegisterUserModel ChatRegisterUserOutput;

        public List<ChatRegisterUserModel> ChatRegisteredUsers;

        public List<ChatRegisterUserModel> ChatRegisteredUserFriends;

        public ResponseModel responseModel;
    }
}
