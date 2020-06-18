namespace SocialCommunicationsBL.BusinessLogic.ChatLogic
{
    using SocialCommunicationDA.SqlServerLogic.ChatLogic;
    using SocialCommunicationModels.ChatInputAndOutputModels;

    public class GetChatUsersWithoutFriends
    {
        public OutputModel ChatUsersWithoutFriendsGet(InputModel inputModel)
        {
            OutputModel outputModel;

            GetChatUsersWithoutFriendsDL getChatUsersWithoutFriendsDL = new GetChatUsersWithoutFriendsDL();

            outputModel = getChatUsersWithoutFriendsDL.ChatUsersWithoutFriendsGet(inputModel);

            if (outputModel?.Friends?.Count > 0 || outputModel.responseModel.ExecutionStatus == 1)
            {
                outputModel.ExecutionalStatus = SocialCommunicationModels.CommonModels.ExecutionStatusEnums.ExecutionStatus.Success;
            }
            else
            {
                outputModel.ExecutionalStatus = SocialCommunicationModels.CommonModels.ExecutionStatusEnums.ExecutionStatus.Failed;
            }

            return outputModel;
        }


    }
}
